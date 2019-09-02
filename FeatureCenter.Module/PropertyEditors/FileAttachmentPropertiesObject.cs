using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Drawing;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.PropertyEditors {

	public class AllFilesFilterAttribute : FileTypeFilterAttribute {
		public AllFilesFilterAttribute(int order) : base("AllFiles", order, "*.*") { }
	}
	public class ImageFileTypeFilterAttribute : FileTypeFilterAttribute {
		public ImageFileTypeFilterAttribute(int order) : base("ImagesFilter", "Image files", order, "*.bmp", "*.png", "*.gif", "*.jpg") { }
	}

	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.FileAttachmentPropertiesHint)]
	[FileAttachment("Document")]
	[ImageName("BO_FileAttachment")]
	public class FileAttachmentProperties : NamedBaseObject {
		private FileData document;
		private FileData picture;

		public override void AfterConstruction() {
			base.AfterConstruction();
			document = new FileData(Session);
			picture = new FileData(Session);
		}
		public FileAttachmentProperties(Session session) : base(session) { }
		[Aggregated, Association("FileAttachmentPropertiesObject-AssociatedFiles")]
		//[FileTypeFilter("ArchieveFiles", 1, "*.rar", "*.zip")]
		//[FileTypeFilter("AllFiles", 2, "*.*")]
		public XPCollection<FileCollectionItem> Files {
			get { return GetCollection<FileCollectionItem>("Files"); }
		}
		[Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
		[FileTypeFilter("DocumentFiles", 1, "*.txt", "*.doc")]
		[FileTypeFilter("AllFiles", 2, "*.*")]
		public FileData Document {
			get { return document; }
			set { SetPropertyValue("Document", ref document, value); }
		}
		[Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
		[ImageFileTypeFilter(1)]
		[AllFilesFilter(2)]
		public FileData Picture {
		get { return picture; }
		set { SetPropertyValue("Picture", ref picture, value); }
}
	}

	[FileTypeFilter("DocumentsFilter", "Document files", 1, "*.txt", "*.doc")]
	[ImageFileTypeFilter(2)]
	[AllFilesFilter(3)]
	public class FileCollectionItem : FileAttachmentBase {
		[Persistent, Association("FileAttachmentPropertiesObject-AssociatedFiles")]
		protected FileAttachmentProperties owner;
		public override void AfterConstruction() {
			base.AfterConstruction();
			File = new FileData(Session);
		}
		public FileCollectionItem(Session session) : base(session) { }
	}
}
