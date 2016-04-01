using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class MainPageModel
    {

        private string _presentation = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris dignissim mauris id feugiat scelerisque. Fusce est ante, placerat ac elit eu, consectetur rutrum augue. Integer ornare sapien eget dolor tincidunt rutrum. Aenean id purus vehicula, porta tortor sed, iaculis urna. Nam vel ex venenatis, facilisis eros in, lacinia diam. Fusce ut elementum orci. Duis lobortis augue at orci molestie convallis. Ut lorem magna, congue quis dolor vel, rutrum sollicitudin turpis. Sed at sollicitudin mi. Maecenas tristique convallis aliquet. Morbi commodo ultricies sodales. Donec tempus pellentesque dapibus.";
        public string presentation
        {
            get{ return _presentation;}
            set{_presentation=value;}
        }
    }
}