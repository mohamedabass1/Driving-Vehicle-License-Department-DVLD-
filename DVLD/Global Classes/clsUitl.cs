using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    static public class clsUitl
    {

        static public bool CreateFolderIfDoseNotExist(string DestinationFolder)
        {

            if (!Directory.Exists(DestinationFolder))
            {
                try
                {  // If it doesn't exist, create the folder
                    Directory.CreateDirectory(DestinationFolder);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
        }
        static public string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        static public string ReplaceTheImageFileName(string SourceFile)
        {
            // Full file name. Change your file name   
            string fileName = SourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }
        static public bool CopyThePersonImageToProjectFolder(ref string SourceFile)
        {

            // this funciton will copy the image to the
            // project images folder after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name

            string DestinationFolder = @"A:\DVLD-People-Images\";

            if (!CreateFolderIfDoseNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceTheImageFileName(SourceFile);

            try
            {
                File.Copy(SourceFile, destinationFile);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = destinationFile;

            return true;

        }
    }
}
