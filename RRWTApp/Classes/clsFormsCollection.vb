Public Class clsFormsCollection : Implements IEnumerable
    Private c As New Collection()
    Sub Add(ByVal f As Form)
        c.Add(f)
    End Sub
    Sub Remove(ByVal f As Form)
        Dim itemCount As Integer
        For itemCount = 1 To c.Count
            If f Is c.Item(itemCount) Then
                c.Remove(itemCount)
                Exit For
            End If
        Next
    End Sub
    ReadOnly Property Item(ByVal index) As Form
        Get
            Return c.Item(index)
        End Get
    End Property
    Overridable Function GetEnumerator() As  _
    IEnumerator Implements IEnumerable.GetEnumerator
        Return c.GetEnumerator
    End Function
End Class
