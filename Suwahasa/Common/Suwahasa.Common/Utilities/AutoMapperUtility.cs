using AutoMapper;

namespace Suwahasa.Common.Utilities
{
    public static class AutoMapperUtility<S, T>
    {
        public static T GetMappedObject(S source, IMapper mapper)
        {
            return mapper.Map<T>(source);
        }
    }
}
