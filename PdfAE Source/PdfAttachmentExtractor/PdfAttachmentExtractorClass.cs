using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class PdfAttachmentExtractorClass
{
    public static List<string> ExtractAttachments(string sourcePdf, string outputDirectory)
    {
        try
        {
            List<string> attachmentfiles = new List<string>();
            PdfReader reader = new PdfReader(sourcePdf);
            PdfDocument pdfDoc = new PdfDocument(reader);

            PdfDictionary names = pdfDoc.GetCatalog().GetPdfObject().GetAsDictionary(PdfName.Names);
            PdfDictionary embeddedFiles = names?.GetAsDictionary(PdfName.EmbeddedFiles);

            if (embeddedFiles != null)
            {
                PdfArray filespecs = embeddedFiles.GetAsArray(PdfName.Names);

                if (filespecs != null)
                {
                    for (int i = 0; i < filespecs.Size(); i++)
                    {
                        PdfDictionary file = filespecs.GetAsDictionary(i);

                        if (file != null)
                        {
                            PdfDictionary paramsDict = file.GetAsDictionary(PdfName.EF);

                            if (paramsDict != null)
                            {
                                foreach (PdfName key in paramsDict.KeySet())
                                {
                                    PdfStream stream = paramsDict.GetAsStream(key);
                                    string attachedFileName = file.GetAsString(key)?.ToString();
                                    byte[] attachedFileBytes = stream?.GetBytes();

                                    if (!string.IsNullOrEmpty(attachedFileName) && attachedFileBytes != null)
                                    {
                                        string filePath = Path.Combine(outputDirectory, attachedFileName);
                                        if (!attachmentfiles.Contains(filePath))
                                        { 
                                        attachmentfiles.Add(filePath);
                                        }
                                        File.WriteAllBytes(filePath, attachedFileBytes);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Directory.CreateDirectory(outputDirectory);
            pdfDoc.Close();
            return attachmentfiles;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error extracting attachments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }


}