   M S B A M L   `   `   `  ����E  ARecordBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:RecordBook.ViewsRecordBook.Views  5   	   =#clr-namespace:RecordBook.ViewModelsRecordBook.ViewModels  5   	   -    'RecordBook.Views.CreateRecordBookWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:RecordBook.Views     5   	   2vm#clr-namespace:RecordBook.ViewModels     5   	     � Title$  CreateRecordBookWindow��5	   	   $	��450��6(   $	��800��65   .��5
      � 
������� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!   ._�5      �� $��ФИО студента��6   5      �� 5   
   $��0��6   $��1��6!   ._�5      �� $.��(Номер зачетной книжки��6   5      �� 5    
   $��0��6   $��2��6!   ._�5!      �� $��Курс��6   5"      �� 5#   
   $��0��6   $��3��6!   ._�5$      �� $��Группа��6   5%      �� 5&   
   $��0��6   $��4��6!   ._�5'      �� $��Университет��6   5(      �� 5)   
   $��0��6   $��5��6!   ._�5*      �� $ ��Специальность��6   5+      �� 5,   
   $��1��6   $��2��6#   $��10q�60   ��6=   �� *	Courses+ �� SelectedItem 6]   �� *Course+�� 5.   
   $��1��6   $��0��6"   ��60   �� *Fio+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5/   
   $��1��6   $��1��6"   ��60   �� *NumberRecordBook+$ PropertyChanged=�$ TwoWay=��� 50   
   $��1��6   $��3��6"   ��6/   �� *Group+$ PropertyChanged=�$ TwoWay=��� 51   
   $��1��6   $��4��6"   ��6/   �� *
University+$ PropertyChanged=�$ TwoWay=��� 52   
   $��1��6   $��5��6"   ��6/   �� *
Speciality+$ PropertyChanged=�$ TwoWay=��� 53   
   $��1��6   $��6��6!   $��Создать��6.   $��20(�6@   ��6N   �� *CreateCommand+54      55      