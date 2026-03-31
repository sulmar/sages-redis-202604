using CsvHelper.Configuration;
using icd10_api.Models;

namespace icd10_api.Configurations;

public class ClassificationMap : ClassMap<ClassificationRecord>
{
    public ClassificationMap()
    {
        Map(p => p.Code).Name("Code");
        Map(p => p.Group).Name("Group");
        Map(p => p.Category).Name("Category");  
        Map(p => p.CategoryCode).Name("Category code");
    }
}
