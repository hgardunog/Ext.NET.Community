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

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class SubmittedNode
    {
        private string nodeID;
        private string clientID;
        private string text;
        private string path;
        private JsonObject attributes;
        private List<SubmittedNode> children;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SubmittedNode(string path, string text, string nodeID, JsonObject attributes, List<SubmittedNode> children)
        {
            this.path = path;
            this.nodeID = nodeID;
            this.text = text;
            this.attributes = attributes;
            this.children = children;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [JsonConstructor]
        public SubmittedNode(string path, string text, string nodeID, string clientID, JsonObject attributes, List<SubmittedNode> children)
            : this(path, text, nodeID, attributes, children)
        {
            this.clientID = clientID;
        }

        public TreePanelBase Tree 
        { 
            get; 
            set; 
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public List<SubmittedNode> Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = new List<SubmittedNode>();
                }

                return this.children;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string NodeID
        {
            get 
            { 
                return this.nodeID; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string ClientID
        {
            get 
            { 
                return this.clientID; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Text
        {
            get 
            { 
                return this.text; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Path
        {
            get 
            { 
                return this.path; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Checked
        {
            get
            {
                if (this.Attributes.Count > 0)
                {
                    if (this.Attributes.ContainsKey("checked"))
                    {
                        object value = this.Attributes["checked"];

                        return value != null ? (bool)value : false;
                    }
                }

                return false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual JsonObject Attributes
        {
            get
            {
                if (this.attributes == null)
                {
                    this.attributes = new JsonObject();
                }

                return this.attributes;
            }
        }

        public NodeProxy ToProxyNode()
        {
            return this.Tree.GetNodeById(this.NodeID ?? this.ClientID);
        }

        public NodeProxy ToProxyNode(TreePanelBase tree)
        {
            return (tree ?? this.Tree).GetNodeById(this.NodeID ?? this.ClientID);
        }
    }
}