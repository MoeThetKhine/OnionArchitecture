using OnionArchitecture.DTOs.Features.PageSetting;

namespace OnionArchitecture.DTOs.Features.Blog;

public class BlogListModel
{
	public IEnumerable<BlogModel> DataLst { get; set; }
	public PageSettingModel PageSetting { get; set; }
}
