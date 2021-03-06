﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shared.Database;

[DataTable(DatabaseName = "Characters", TableName = "Creation_Names", PreCache = true)]
[Serializable]
public class Creation_Name : DataObject
{
    [DataElement(Unique=true,Varchar=9)]
    public string Name;
}