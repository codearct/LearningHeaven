# Communication between Components-4

## EventCallback/Delegate

- EventCallback is communication between parent component and its child component
- But direction is from child to parent
- The value created by child component is displayed inside the parent component
- Not under child component used inside parent component
- That means data created by child component move up to parent component
- How to implement:
    - Create EventCallback parameter in child component
    ```
    [Parameter]
    public EventCallback<int> SetChildCurrentCount { get; set; }

    private int childCurrentCount = 0;

    private void IncrementCount()
    {
        childCurrentCount++;
        SetChildCurrentCount.InvokeAsync(childCurrentCount);
    }
    ```
    - Move data with that parameter to parent
    ```
    <ChildComponent SetChildCurrentCount="SetParentCurrentCount"/>
    ```
    - Catch the data with parent parameter
    ```
    private int parentCurrentCount;

    private void SetParentCurrentCount(int childCurrentCount)
    {
        parentCurrentCount = childCurrentCount;
    }
    ```
    - Display that at html part
    ```
    Count: @parentCurrentCount
    ```
- EventCallback is similar c# delegate but not same
    - When EventCallback is invoked you don t have to be empty or not but delegate have not to be empty.If it is ,ide will throw an exception
    - You have to use "StateHasChanged" inside parent for re-render when invoke the delegate.