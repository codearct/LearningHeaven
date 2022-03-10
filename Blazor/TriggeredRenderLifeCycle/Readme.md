# Component LifeCylcle-1

## When Is Rendering Triggered
- Blazor component is stateful component
- Render component under 4 condition
    1. When components are created
        - When you just load a component for the first time,it is created
        - When you navigate it and navigate it back,it s created
        - Or when you refresh the page component will be created
    2. When components' events are triggered
        - Not every type of event like timer event have to be UI event
        - UI event has to happend within the component.It cannot happen outside the component
        - One exception:Templated Component,event would happen outside the component.Because template component is part of  child component but also it is defined at parent component 
    3. When components' parameter values are changed
    4. When developers manually trigger the rendering
