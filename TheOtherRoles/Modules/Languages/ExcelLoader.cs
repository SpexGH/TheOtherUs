using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TheOtherRoles.Modules.Languages;

public class ExcelLoader : LanguageLoaderBase
{
    public ExcelLoader()
    {
        Filter = [".excel", ".xls", "xlsx"];
    }

    public override void Load(LanguageManager _manager, Stream stream, string FileName)
    {
        var data = ReadExcel(stream);
        var index = 0;
        foreach (DataColumn column in data.Columns)
        {
            index++;
            if (index == 0)
            {
                continue;
            }

            var langId = column.ColumnName.PareNameToLangId();
            foreach (DataRow Row in data.Rows)
            {
                _manager.AddToMap(langId, (Row[data.Columns[0]] as string)!, (Row[column] as string)!);
            }
        }

    }
    
    public DataTable ReadExcel(Stream stream)
    {
        var dtTable = new DataTable();
        var rowList = new List<string>();
        ISheet sheet;
        
        var xssWorkbook = new XSSFWorkbook(stream);
        sheet = xssWorkbook.GetSheetAt(0);
        var headerRow = sheet.GetRow(0);
        int cellCount = headerRow.LastCellNum;
        for (var j = 0; j < cellCount; j++)
        {
            var cell = headerRow.GetCell(j);
            if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
            {
                dtTable.Columns.Add(cell.ToString());
            } 
        }
        for (var i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            var row = sheet.GetRow(i);
            if (row == null) continue;
            if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (row.GetCell(j) == null) continue;
                if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                {
                    rowList.Add(row.GetCell(j).ToString());
                }
            }
            if(rowList.Count>0)
                dtTable.Rows.Add(rowList.ToArray());
            rowList.Clear(); 
        }
        return dtTable;
    }
}