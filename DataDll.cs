namespace DataDll
{
    public class FormField
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
    }

    public class DataGridColumn
    {
        public string Header { get; set; }
        public string Name { get; set; }
    }

    public class FormConfig
    {
        public string Next { get; set; }
        public Dictionary<string, string> Actions { get; set; }
    }

    public class Config
    {
        
        public List<FormField> FormFields { get; set; }
        public List<DataGridColumn> DataGridColumns { get; set; }
        public Dictionary<string, FormConfig> Forms { get; set; }
    }
}
