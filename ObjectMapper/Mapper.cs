using ObjectMapper.Interfaces;
using System;
using System.Xml;

namespace ObjectMapper
{
    public class Mapper<TIn,TOut> : INormalMapper<TIn,TOut> 
    {
        public IGenericMapper<TIn,TOut> Objectmapper { get; }

        public Mapper(IGenericMapper<TIn, TOut> objectmapper)
        {
            Objectmapper = objectmapper;
        }

        public TOut Map(TIn @in)
        {            
            return Objectmapper.Map(@in); ;
        }

        public TIn Map(TOut @in)
        {
            throw new NotImplementedException();
        }
    }
}
