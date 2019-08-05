using System;
using EpiServer.AlloyDemo.GraphAPI.Models.Media;
using EPiServer.Core;
using EPiServer.Shell;

namespace EpiServer.AlloyDemo.GraphAPI.Business.UIDescriptors
{
    public class FileIconDescriptor<T> : UIDescriptor<T> where T : ContentData
    {
        public FileIconDescriptor()
        {
            Type type = GetType();
            string fileTypeName = type.BaseType.GetGenericArguments()[0].Name;
            IconClass = fileTypeName.Replace("File", "").ToLower() + "Icon";
        }
    }

    [UIDescriptorRegistration]
    public class PdfFileDescriptor : FileIconDescriptor<PDFFile> { }
}
