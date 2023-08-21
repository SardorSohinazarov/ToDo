using ToDo.ViewModel;

namespace ToDo;

public partial class Detail : ContentPage
{
	public Detail(DetailViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}