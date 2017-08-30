using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FakeApi.Domain.Enums
{
    public enum VerbType
    {
        [Description("Get")]
        GET = 0,
        [Description("Post")]
        POST = 1,
        [Description("Put")]
        PUT = 2,
        [Description("Patch")]
        PATCH = 3,
        [Description("Delete")]
        DELETE = 4,
        [Description("Options")]
        OPTIONS = 5
    }
}