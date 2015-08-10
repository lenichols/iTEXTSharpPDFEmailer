# PDF-EMAIL-GENERATOR
iTextSharp HTML Form to Emailed PDF Sender (using SendMail) with Canvas Signature using ASPX.NET (C#)

1. web.config - set your db connection information here
2. form.cs - .cs files contain the form specific methods to sync to the db, generate the PDF and send the email w/ any attachments (configure seperate .cs file for ea form needed)
3. aspx page - if you are posting using ajax - set the post url to: http://yoururl.com/form.aspx/InitiatingFunctionNameHere/
4. Use something like mailgun to control email sends to avoid placement into spam or junkmail (this template uses mailgun)
5. AppCode/PDFHelper.cs - iText helper file... grabs the pdf form fields, applies them to the pdf and outputs (add seperate PDFGenerator and call it from the app .cs file)
