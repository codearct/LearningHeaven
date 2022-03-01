# Blazor Component Basics
## Page Component
- Page components fill @body in MainLayout
- One page would have multiple routes
  - "/sales"
  - "/salesperson
  - Page component calls also as routeable component
- One route must have one page. Otherwise it gives me error
- Page component looks like c# class below
    ```
    [Route("/sales")]
    public class SalesComponent
    {
        ...
    }
    ```
## Non-Page Component
- Non-page components are reusable
- add _importRazor as @using

## Component Structure
- Component has two parts
  - html part
  - c# code part 
    (contains UI logics) 
## Component Inheritance
- sharing features should be base component