﻿using FakeApi.Domain.Enums;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace FakeApi.Domain.Models
{
    public class RestMock
    {
        [BsonId]
        public int IdRestMock { get; set; }
        public string Path { get; set; }
        public string Verb { get; set; }
        public List<RestMockHeader> Headers { get; set; }
        public int ResponseStatus { get; set; }
        public string ContentType { get; set; }
        public string ContentEncoding { get; set; }
        public string ResponseBody { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public RestMock()
        {
            this.Headers = new List<RestMockHeader>();
        }
    }
}