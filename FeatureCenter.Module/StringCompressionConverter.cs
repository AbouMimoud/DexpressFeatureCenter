using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo.Metadata;
using DevExpress.Persistent.Base;
using System.IO;

namespace FeatureCenter.Module {
	public class StringCompressionConverter : ValueConverter {
		public override object ConvertToStorageType(object value) {
			if(((string)value == string.Empty) || ((string)value == null)) {
				return null;
			}
			else {
				return CompressionUtils.Compress(new MemoryStream(System.Text.Encoding.UTF8.GetBytes((string)value))).ToArray();
			}
		}
		public override object ConvertFromStorageType(object value) {
			if(value != null) {
				byte[] decompressedValue = CompressionUtils.Decompress(new MemoryStream((byte[])value)).ToArray();
				if(decompressedValue != null) {
					return System.Text.Encoding.UTF8.GetString(decompressedValue);
				}
			}
			return null;
		}
		public override Type StorageType {
			get { return typeof(byte[]); }
		}
	}

}
