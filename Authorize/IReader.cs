using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize;

public interface IReader
{
    bool Read(string path,string login);
}
