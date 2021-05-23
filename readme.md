# Text Editor 

An example of an app based on MVP pattern. The FileManager class represents business logic, MainForm.cs is a view, and the class Presenter is the presenter.

string Content { get; set; } and string Path { get; } are properties of the view which is passed to the presenter. 

Also, the events of the form FileOpenClick, FileSaveClick, and ContentChanged are passed to the presenter in order to handle them there.