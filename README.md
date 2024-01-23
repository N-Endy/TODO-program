# TODO-program
A TODO application written in C#

It displays option to see all TODOs, Add a TODO, Remove a TODO, or Exit the program in the format below:

```
What do you want to do?
[S]ee all TODOs
[A]dd a TODO
[R]emove a TODO
[E]xit
```

There are unique checks applied in this application, e.g, only unique TODOs can be added. Also while attempting to remove an item, the correct index must be provided. An error is thrown with the user re-prompted for the right index when this happens.
