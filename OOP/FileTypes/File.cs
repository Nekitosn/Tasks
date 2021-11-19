namespace Input_and_handler.FileTypes
{
    public abstract class File
    {
        private string FileType { get; set; }
        protected string Name { get; private set; }
        protected string Extension { get; private set; }
        protected string Size { get; private set; }


        public virtual File GetFileInfo(string str)
        {
            this.FileType = this.GetFileType(str);
            this.Name = this.GetFileName(str);
            this.Extension = this.GtFileExtensiom(str);
            this.Size = this.GetFileSize(str);
            return this;
        }

        public abstract void Display();

        private string GetFileType(string str)
        {
            return str.Trim().Remove(str.IndexOf(":"));
        }
        private string GetFileName(string str)
        {
            str = str.Trim().Remove(0, str.IndexOf(":") + 1);
            str = str.Remove(str.IndexOf("("));
            return str;
        }
        private string GtFileExtensiom(string str)
        {
            //Если файл будет формата .text - нужно будет доработать, ибо отображение расширения будет некоректно
            str = str.Trim().Remove(0, str.IndexOf("(") - 3);
            str = str.Remove(str.IndexOf("("));
            return str;
        }
        private string GetFileSize(string str)
        {
            str = str.Trim().Remove(0, str.IndexOf("(") + 1);
            str = str.Remove(str.IndexOf(")"));
            return str;
        }
    }
}
