using System;
using System.IO;
class WSP2WEM
{
	static void Main()
	{
		DirectoryInfo indir = new DirectoryInfo (".");
		FileInfo [] files = indir.GetFiles("*.wsp");
		

	foreach (FileInfo fi in files)
		{
		byte [] filedata = File.ReadAllBytes(fi.Name);

		int beginindx = 0;
		int endindx = 0;
		int filenum = 1;
		
		for(int k=4; k<filedata.Length; k++)
			{
				if (filedata [k] == 82) //R
				{
					if (filedata [k+1] == 73) //I
					{
						if (filedata [k+2] == 70) //F
						{
							if (filedata [k+3] == 70) //F
							{
							endindx = k;
							byte [] destination = new byte[endindx-beginindx];
							Array.Copy(filedata, beginindx, destination, 0 , endindx-beginindx);
						
							FileStream fs = new FileStream(fi.Name+"_"+filenum+"_"+".wem",FileMode.Create);
							BinaryWriter bw = new BinaryWriter(fs);
							bw.Write(destination);
							bw.Close();
							fs.Close();
							filenum++;
							beginindx = k;
							k+=4;
							}
						}
					}
				}
			}
			
		endindx = filedata.Length;
		byte [] dest = new byte[endindx-beginindx];
						Array.Copy(filedata, beginindx, dest, 0 , endindx-beginindx);
						
						FileStream nfs = new FileStream(fi.Name+"_"+filenum+"_"+".wem",FileMode.Create);
						BinaryWriter nbw = new BinaryWriter(nfs);
						nbw.Write(dest);
						nbw.Close();
						nfs.Close();
	
		}
	}
}
		