using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CSVSharp
{
    public class CSV
    {
        public dynamic Data;
        public string Path;
        public bool Append = false;
        public bool ColumnHeaders = true;

        public void Write()
        {
            // Checking passed in args are valid.
            if (string.IsNullOrEmpty(Path))
                throw new Exception("Path is Null or Empty");

            // Creating a new instance of StringBuilder.
            StringBuilder sb = new StringBuilder();

            if (Data as System.Collections.IEnumerable != null)
            {
                for (int i = 0; i < Data.Count; i++)
                {
                    // If first iteration in the loop.
                    if (i == 0)
                    {
                        // If the Column Headers value is true and the Append value is false.
                        // Note: Column Headers value is set to true and Append value is set to false by default.
                        if (ColumnHeaders && !Append)
                        {
                            // Creating a List of Property Keys from the first object in DataToWrite.
                            IList<PropertyInfo> propkeys = new List<PropertyInfo>(Data[i].GetType().GetProperties());
                            // For each Property Key in the object.
                            for (int z = 0; z < propkeys.Count; z++)
                            {
                                // If last iteration in loop, create a newline.
                                if (z == (propkeys.Count - 1))
                                    sb.Append(propkeys[z].Name + Environment.NewLine);
                                else
                                    sb.Append(propkeys[z].Name + ",");
                            }
                        }
                    }

                    // Creating a list of Propertys from the current object in DataToWrite.
                    IList<PropertyInfo> props = new List<PropertyInfo>(Data[i].GetType().GetProperties());
                    // For each Property in the current object.
                    for (int x = 0; x < props.Count; x++)
                    {
                        // Getting values from object passed into method.
                        object propValue = props[x].GetValue(Data[i], null);
                        //If value contains a quotation mark, double it up.
                        propValue.ToString().Replace("\"", "\"\"");
                        // If value contains a semicolon, wrap the string in quotation marks.
                        if (propValue.ToString().Contains(","))
                            propValue = "\"" + propValue + "\"";

                        // If last iteration in loop, create a newline.
                        if (x == (props.Count - 1))
                            sb.Append(propValue.ToString() + Environment.NewLine);
                        else
                            sb.Append(propValue.ToString() + ",");
                    }

                }
            }

            // DataToWrite is NOT IEnumerable.
            else
            {
                // If the Column Headers value is true and the Append value is false.
                // Note: Column Headers value is set to true and Append value is set to false by default.
                if (ColumnHeaders && !Append)
                {
                    IList<PropertyInfo> propkeys = new List<PropertyInfo>(Data.GetType().GetProperties());
                    for (int i = 0; i < propkeys.Count; i++)
                    {
                        if (i == (propkeys.Count - 1))
                            sb.Append(propkeys[i].Name + Environment.NewLine);
                        else
                            sb.Append(propkeys[i].Name + ",");
                    }
                }
                // Creating a list of Propertys from DataToWrite.
                IList<PropertyInfo> props = new List<PropertyInfo>(Data.GetType().GetProperties());
                for (int x = 0; x < props.Count; x++)
                {
                    // Getting values from object passed into method.
                    object propValue = props[x].GetValue(Data, null);
                    //If value contains a quotation mark, double it up.
                    propValue.ToString().Replace("\"", "\"\"");
                    // If value contains a semicolon, wrap the string in quotation marks.
                    if (propValue.ToString().Contains(","))
                        propValue = "\"" + propValue + "\"";

                    // Append value to String Builder.
                    if (x == (props.Count - 1))
                        sb.Append(propValue.ToString() + Environment.NewLine);
                    else
                        sb.Append(propValue.ToString() + ",");
                }
            }

            // Write data to a CSV.
            using (StreamWriter CSVFile = new StreamWriter(Path, Append))
            {
                CSVFile.Write(sb.ToString());
            }
        }
    }
}