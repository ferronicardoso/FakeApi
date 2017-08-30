using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeApi.Domain.Dtos
{
    public class RestMockGridDto
    {
        public int IdRestMock { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string Path { get; set; }
        public string Verb { get; set; }
    }
}
