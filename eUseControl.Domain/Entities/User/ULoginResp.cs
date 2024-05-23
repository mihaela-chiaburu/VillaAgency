using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ULoginResp
{
    public bool Status { get; set; }
    public string StatusMsg { get; set; }
    public UserMinimal UserMinimal { get; set; }
}

