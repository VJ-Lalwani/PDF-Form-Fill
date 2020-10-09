        string src = inputpdfpath;
        string dest = outputpdfpath;
        string destxml = xmlpath;

        iText.Kernel.Pdf.PdfReader reader = new iText.Kernel.Pdf.PdfReader(src);
        iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(dest);
        FileStream fs = new FileStream(destxml, FileMode.Open, FileAccess.Read);
        try
        {
            iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer, new StampingProperties().UseAppendMode());           

            iText.Forms.PdfAcroForm form = iText.Forms.PdfAcroForm.GetAcroForm(pdfDoc, true);
            iText.Forms.Xfa.XfaForm xfa = form.GetXfaForm();

            // Method fills this object with XFA data under datasets/data.
            xfa.FillXfaForm(fs, true);            
            xfa.Write(pdfDoc);


            pdfDoc.Close();
            fs.Close();
            reader.Close();
            writer.Close();

        }
        catch(Exception ex)
        {
            reader.Close();
            writer.Close();
            fs.Close();
        }
