   M S B A M L   `   `   `  ����B  >Hangman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Hangman.ViewHangman.View  5      5clr-namespace:Hangman.ViewModelHangman.ViewModel  5          Hangman.View.GameView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Hangman.View     5      5	viewModelclr-namespace:Hangman.ViewModel     5      -   5        $
��Game��5	   8     � 	Resources  5         BoolKey��%   &	        �� 5   
   6'   5      .��5      � 
���   � � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $��70 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�50   
   ]� $��1��6   $��0��6!   .+�51      �� $��35(�52      
���  �� �� TextAlignment$
 Left=�53      $	��Top=�54      
������ $��15 0 0 0q�56      ��51      �� *_CurrentPlayer+56      �� 57      $`��ZC:\Users\UltraBook\Desktop\Anul_II\Semestrul_2\MVP\Tema2\Hangman\Hangman\Images\images.jpg��6   $
��Fill=�58      $��
15 5 15 15q�59      5:      �� 5<   
   
���  ��$��35(�5=   %   $��Center=�5>      $��Center=�61   
������ $��2��5@      $��0��6!   $��2��61   ��5<      �� *WordToGuess+5A      �� 5C   
   $��New Game��6   $��40��5E      $	��100��6   $��20(�5F      
�������
���   �$��0q�5G   ;   $��2��5H      $��3��6!   ��5D      �� *NewGameCommand+5I      �� 5K   
   $��1��6   $��2��6"   $��2��62   $��7q�6C   .+�5L      �� ��6   �� *	ImgPath+5M      �� 5O   
   $��15q�6   $��3��5P      $��0��5Q      $��2��5R      $��Center=�5T      $��Bottom=�60   ��5S      �� *ButtonsCollection+��5U      �� 5V      .R�5W      �� $��20(�5[   "   
��� � �$��50��5\   "   $��50��6.   $��5q�69   $��Center=�5]   "   $��Center=�6F   ��5W      �� *Letter+y�5X   "   �� *Button_Visibility+ �� 	Converter# [  ��5Y   "   �� *#!DataContext.CreateKeyboardCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ ItemsControlL���5Z   "   �� *Letter+5]   F   5^      ��5a      �� 5b      .R�5c      �  � Orientation$ 
Horizontal=�6    5d      5f      5g      5h      