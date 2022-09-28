//using AutoMapper;
//using Core.Models;

//namespace Restaurant_Delivery.Helpers
//{
//    public class MenuUrlResolver: IValueResolver<MenuItem, MenuItemDTO, string>
//    {
//        private readonly IConfiguration _config;

//        public MenuUrlResolver(IConfiguration config)
//        {
//            _config = config;
//        }

//        public string Resolve(MenuItem source, MenuItemDTO destination, string destMember, ResolutionContext context)
//        {
//            if (!string.IsNullOrEmpty(source.PicUrl))
//            {
//                return _config["ApiUrl"] + source.PicUrl;
//            }

//            return null;
//        }
//    }
//}
