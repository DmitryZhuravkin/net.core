A view component is a C# class that provides a partial view with the data that it needs, 
independently from the parent view and the action that renders it. In this regard,
a view component can be thought of as a specialized action, but one that is used only to provide a partial
view with data; it cannot receive HTTP requests, and the content that it provides will always be included in
the parent view.


Ways to create view components:
1. POCO
2. Inherit from ViewComponent
3. Use ViewComponentAttribute