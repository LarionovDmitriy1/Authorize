using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize;

public interface IAuthorization
{
    public void Login();

    public void Password(string login);
    
}
