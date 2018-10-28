using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Common
{
   public  class Utils
    {
        /// <summary>
        /// 遍历控件中的所有元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static List<T> ReadAllControls<T>(Control control) where T : class
        {
            List<T> controlList = new List<T>();
            if (control.Controls.Count < 1)
            {
                return controlList;
            }

            foreach (Control c in control.Controls)
            {
                if (c is T)
                {
                    controlList.Add(c as T);
                }

                if (c.Controls.Count > 0)
                {
                    controlList.AddRange(ReadAllControls<T>(c));
                }
            }
            return controlList;

        }
    }
}
