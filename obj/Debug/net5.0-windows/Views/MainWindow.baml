   M S B A M L   `   `   `  ����E  ARecordBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RecordBook
RecordBook  5   	   5clr-namespace:RecordBook.ModelsRecordBook.Models  5   	   =#clr-namespace:RecordBook.ViewModelsRecordBook.ViewModels  5   	       RecordBook.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RecordBook     5   	   -mclr-namespace:RecordBook.Models     5   	   2vm#clr-namespace:RecordBook.ViewModels     5   	     � Title$  Record Book��5
   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�5   
   .��5      � 
���� �� � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� .+�5      �� $��0��6   $��30��6"   $��30��62   $%��Поставить оценку��6A   
����� ���6p   �� *AddMarkCommand+�� 5      $��1��6   $��30��6"   $��30��62   $"��Редактирование��6A   
����� ���6l   �� *EditCommand+�� 5      $��2��6   $��30��6"   $��30��62   $!��Красный диплом��6A   
����� ���6l   �� *CalculateProbabilityCommand+5       �� 55   
   $��1��6   $��2��6#   $#��Зачетные книжки��64   .��56      �� 
����+�����#6C8CD5$	��130��59      $��Futura PT Book Italic)�6*   $��10q�5:      ��57      �� *RecordBooksChoosen+ �� SelectedItem 58      �� *CurrentRecordBook+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5;      �� 5<      .R�5=      �  5>      �� 5?   "   $��60 �63   �� 5@   "   $��60 �63   �� 5A   "   $��* �63   .+�5D      �� 
�������$��0��6;   ��6K   �� *Number+�� 5E      
�������$��1��6;   ��6K   �� *Group+�� 5F      
�������$��2��6;   ��6K   �� *FIO+5G      5H      5J      5K      �� 5L   
   $��1��6   $��3��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5M      �� .��6   LJВВедите номер зачтеки или ФИО для поиска6?   �� 5N      
����� �$	��100��6)   $��20��65   ��6B   �� *Finder+$ PropertyChanged=�$ TwoWay=�6�   �� 5O      
����� �$��20��6'   ��63   �� *FindCommand+.��6S   Find6Z   5P      �� 5R   
   $��2��6   $��1��6   ��6-   �� *Info+$ PropertyChanged=�$ TwoWay=�6y   � 5S   
   $��2��6    5T      �� 5U      $��* �6    �� 5V      $��* �6    .+�5X      �� $��0��6   
�������$%��Выберите семестр��64   $��Center=�6O   $��2��6l   $	��Top=�6}   �� 5Y      
����� �$��1��6)   $��
15,0,15,15q�66   $��13(�5Z      $��Center=�6-   ��5[      �� *Terms+$ PropertyChanged=�$ OneWay=� 5\      �� *CurrentTerm+5^      5_      �� 5`   
   $��3��6   $��15q�6"   .+�5a      �� 
����� �$	��100��6'   $��25��63   $#��Создать зачетку��6?   ��6Z   �� *CreateRecordBookCommand+5c      &   System.Windows.Controls.DataGrid  5d   
   $��1��6   
����� �   
IsReadOnly$
 True��5f      	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 5g      
   ColumnHeaderHeight$
 30Q�5h      $��10q�5i      $��13(�5j      $��Futura PT Book Italic)�5k      $��Center=�5l      ��5m      �� *RBTable[0].DefaultView+$ PropertyChanged=�$ OneWay=�5n      5r      5s      