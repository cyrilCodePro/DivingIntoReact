using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Employees
{
    public class Employees
    {
        public string manager_id;
        public string employee_id;
        public string employee_salary;

        public Employees(String input)
        {
            CSVHelper csv = new CSVHelper(input);
            foreach(string [] t in csv)
            {
                this.employee_id = t[0];
                this.manager_id = t[1];
                this.employee_salary = t[2];

            }

        }

    }
}
public class CSVHelper :
    List<String[]>
{
    protected String csv = String.Empty;
    protected String seperator = ",";

    public CSVHelper (String csv, String separator = "\",\"")
    {
        this.csv = csv;
        this.seperator = seperator;

        foreach (string Line in Regex.Split(csv, System.Environment.NewLine).ToList().Where(String => !String.IsNullOrEmpty(String)))
        {

            String[] values = Regex.Split(Line, seperator);

            for (int i = 0; i < values.Length; i++)
            {
                //Trim Values
                values[i] = values[i].Replace("\"," ");
            }
            this.Add(values);
        }
    }
}
