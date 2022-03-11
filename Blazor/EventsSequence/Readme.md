# Component LifeCycle-2

## Events Sequence

1. When rendering is on first time,those happen below:
    - Parent - SetParameters 
    - Parent - OnInitialized
    - Parent - OnParametersSet
        - Child - SetParameters
        - Child - OnInitialized
        - Child - OnParametersSet
    - Parent - OnAfterRender
        - Child - OnAfterRender
2. When rerendering,those happen below:
    - Parent - ShouldRender 
        - Child? - SetParameters
        - Child? - OnParametersSet
        - Child? - ShouldRender
    - Parent - OnAfterRender
        - Child? - OnAfterRender
