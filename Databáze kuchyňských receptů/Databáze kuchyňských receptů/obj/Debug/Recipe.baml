   M S B A M L   `   `   `  ����[  WDatabáze kuchyňských receptů, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Databáze_kuchyňských_receptů Databáze_kuchyňských_receptů  5   	   -    'Databáze_kuchyňských_receptů.Recipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Databáze_kuchyňských_receptů     5   	   -   5          � Title$  Recipe��5   	   $	��450��6   $	��800��6%   .��5	      � ���#e4eaff � ColumnDefinitions 5
   
   �� 5      $
��0.5* �6   �� 5      $��8* �6   �� 5      $��2* �6   �� 5      $	��10* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $
��0.5* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��8* �6   �� 5      $
��0.5* �6   .+�5   
   � $��5��6   $��5��6    5      �� 5      $��* �6#    5       �� 5!      $��* �6    �� 5"      $��* �6    �� 5#      $
��0.7* �6    �� 5$      $��* �6    .+�5&      �� -   5        $
��Save��5&      $��1��6!   $��0��6.   $��Uložit��6>   
����������#272643$��20(�6w   ��5'      �� 5(       �� 
TargetType" ��6&   .R�5)      �� #��z��6!    �� CornerRadius$ 15��6K   ._�5*      �� $��Center=�6/   $��Center=�6L   #��z��6g   5+      5,      5.      �� 5/      -   5        $��Cancel��5/      $��3��6#   $��0��60   $��Zrušit��6@   
����������#272643$��20(�6y   ��50      �� 51      " ��6&   .R�52      �� #��z��6!   $ 15��6K   ._�53      �� $��Center=�6/   $��Center=�6L   #��z��6g   54      55      57      58      �� 59   
   $��1��6   $��1��6   $��Název:��6-   $��15(�6>   $
��Bold"�6L   �� 5:   
   -   5        $��Title��5:      $��1��6   $��1��6,   $��3��6<   $��
70,0,100,0q�6P   $��20(�6d   $
��Bold"�6r   ���#e4eaff6�   �� 5;   
   -   5        $��Error��5;      $��2��6   $��1��6*   $��3��6:   $��15(�6N   $
��Bold"�6\   �� 5<   
   -   5        $��Author��5<      $��1��6   $��4��6+   $��2��6;   $��15(�6O   �� 5=   
   -   5        $��Vegan��5=      $��4��6    $��4��6-   $��Center=�6=   �� 5>   
   $��4��6   $��4��6   $��2��6-   $��15(�6A   $��Vegetarián��6O   $��20,0,0,0q�6d   $��Center=�6v   �� 5?   
   $��3��6   $��1��6   $��Ingredience:��6-   $��15(�6D   $
��Bold"�6R   �� 5@   
   $��3��6   $��3��6   $��Postup:��6-   $��15(�6?   $
��Bold"�6M   �� 5A   
   -   5        $��Ingredients��5A      $��5��6%   $��1��62   ���#e4eaff6B   �� 5B   
   -	   5        $��Process��5B      $��5��6!   $��3��6.   ���#e4eaff6>   5C      5D      