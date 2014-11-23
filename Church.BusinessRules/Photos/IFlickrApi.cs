using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.BusinessRules.Photos
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFlickrApi
    {
        /// <summary>
        /// Uploads the photo.
        /// </summary>
        /// <param name="stream">The stream.</param>
        void UploadPhoto(Stream stream);
    }
}
