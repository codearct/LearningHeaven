# Communication Between Components-1

## Regular Parameter
- Regular parameters allow communication between parent component and child component
- Move common points between parent components to a new child component
- Describe those common points as parameters
- With [Parameter] attribute
- Properties that have [Parameter] attribute must have public access modifier
- Use that child component inside parent components like html tag
- And change parameters depending on parent components
- Don't forget to add __Imports.razor as @using
- This feature allows us to control parent components from one place