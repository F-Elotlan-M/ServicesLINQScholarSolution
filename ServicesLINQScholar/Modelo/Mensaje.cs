using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicesLINQScholar.Modelo
{
    [DataContract]
    public class Mensaje
    {

        [DataMember]
        public Boolean error { get; set; }
        [DataMember]
        public string mensaje { get; set; }
        [DataMember]
        public usuario usuarioLogin { get; set; }

    }
}