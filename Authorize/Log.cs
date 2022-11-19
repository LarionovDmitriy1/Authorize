using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize;

public class Log
{
	public Log()
	{

	}
	public void Logs(string exception)
	{
        string path = @"C:\Users\Студент1\Desktop\log.txt";
        FileInfo log = new FileInfo(path);
        if (log.Exists)
        {
            using (StreamWriter writeLog = new StreamWriter(path, true))
            {
                writeLog.WriteLine(exception);
                writeLog.WriteLine();
            }
        }
        else
        {
            using (log.Create())
            {

            }
            using (StreamWriter writeLog = new StreamWriter(path, true))
            {
                writeLog.WriteLine(exception);
                writeLog.WriteLine();
            }
        }
    }
}
