/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.1.1 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DateFilter
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("type", new ConfigOption("type", new SerializationOptions(JsonMode.ToLower), null, this.Type ));
                list.Add("beforeText", new ConfigOption("beforeText", null, "Before", this.BeforeText ));
                list.Add("afterText", new ConfigOption("afterText", null, "After", this.AfterText ));
                list.Add("onText", new ConfigOption("onText", null, "On", this.OnText ));
                list.Add("formatProxy", new ConfigOption("formatProxy", new SerializationOptions("dateFormat"), "", this.FormatProxy ));
                list.Add("datePickerOptions", new ConfigOption("datePickerOptions", new SerializationOptions("pickerOpts", JsonMode.Object), null, this.DatePickerOptions ));
                list.Add("maxDate", new ConfigOption("maxDate", new SerializationOptions(typeof(CtorDateTimeJsonConverter)), new DateTime(9999, 12, 31), this.MaxDate ));
                list.Add("minDate", new ConfigOption("minDate", new SerializationOptions(typeof(CtorDateTimeJsonConverter)), new DateTime(0001, 01, 01), this.MinDate ));
                list.Add("valueProxy", new ConfigOption("valueProxy", new SerializationOptions("value", JsonMode.Raw), "", this.ValueProxy ));

                return list;
            }
        }
    }
}