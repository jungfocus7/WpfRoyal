Imports System






Public NotInheritable Class MainForm
    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub


    Protected Overrides Sub OnLoad(tea As EventArgs)
        MyBase.OnLoad(tea)

        MinimumSize = Size
        Text = [GetType]().Namespace




        '_rootCont = CType(_ehrt.Child, RootContainer)
        '_rootCont.SetCallback(AddressOf pf_rootCont__Callback)

    End Sub



End Class
