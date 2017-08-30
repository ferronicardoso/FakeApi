using FakeApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FakeApi.Domain.Dtos
{
    public class RestMockEditDto
    {
        public int IdRestMock { get; set; }
        public string Path { get; set; }
        public VerbType Verb { get; set; }
        public List<RestMockHeaderDto> Headers { get; set; }
        public string ResponseStatus { get; set; }
        public string ContentType { get; set; }
        public string ContentEncoding { get; set; }
        public string ResponseBody { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public IEnumerable<SelectListItem> VerbList { get; set; }
    }
}
