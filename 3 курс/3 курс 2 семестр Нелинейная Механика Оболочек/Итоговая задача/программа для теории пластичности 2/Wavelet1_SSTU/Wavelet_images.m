function varargout = Wavelet_images(varargin)
% WAVELET_IMAGES MATLAB code for Wavelet_images.fig
%      WAVELET_IMAGES, by itself, creates a new WAVELET_IMAGES or raises the existing
%      singleton*.
%
%      H = WAVELET_IMAGES returns the handle to a new WAVELET_IMAGES or the handle to
%      the existing singleton*.
%
%      WAVELET _IMAGES('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in WAVELET_IMAGES.M with the given input arguments.
%
%      WAVELET_IMAGES('Property','Value',...) creates a new WAVELET_IMAGES or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before Wavelet_images_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to Wavelet_images_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help Wavelet_images

% Last Modified by GUIDE v2.5 17-May-2014 18:11:29

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @Wavelet_images_OpeningFcn, ...
                   'gui_OutputFcn',  @Wavelet_images_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT




% --- Executes just before Wavelet_images is made visible.
function Wavelet_images_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to Wavelet_images (see VARARGIN)

% Choose default command line output for Wavelet_images
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes Wavelet_images wait for user response (see UIRESUME)
% uiwait(handles.figure1);

%    VERTICAL_SCROLLBAR_ALWAYS (=22)
%    VERTICAL_SCROLLBAR_NEVER (=21)
%    VERTICAL_SCROLLBAR_AS_NEEDED (=20)
%    HORIZONTAL_SCROLLBAR_ALWAYS (=32)
%    HORIZONTAL_SCROLLBAR_NEVER (=31)
%    HORIZONTAL_SCROLLBAR_AS_NEEDED (=30)

global h_edit1 main_figure main_figure_color t_ref jt_ref Cols ...
    b1_ref b2_ref b3_ref b4_ref st1_ref
 main_figure=gcf;
 main_figure_color=get(main_figure,'Color');
 h_edit1=findobj('Tag', 'edit1');
 b1_ref=findobj('Tag','pushbutton1');
 b2_ref=findobj('Tag','pushbutton2');
 b3_ref=findobj('Tag','pushbutton3');
 b4_ref=findobj('Tag','pushbutton4');
 t_ref=findobj('Tag','uitable1');
 st1_ref=findobj('Tag','text1');

    jScrollPane=findjobj(t_ref);
    jViewPort=jScrollPane.getViewport;
    jt_ref=jViewPort.getComponent(0);
 
%[left, bottom, width, height]
%[left, right, top, bottom]

 link_ui(t_ref,main_figure,'left,right,top,bottom');
 link_ui(h_edit1,main_figure,'right,top,bottom');
 link_ui(st1_ref,main_figure,'right,top'); 
 link_ui(b1_ref,main_figure,'left,bottom');
 link_ui(b2_ref,main_figure,'left,bottom');
 link_ui(b3_ref,main_figure,'right,top');
 link_ui(b4_ref,main_figure,'right,top');

    set(h_edit1,'HorizontalAlignment','left','Max',3,'String','');    
    jScrollPane=findjobj(h_edit1);
    jViewPort=jScrollPane.getViewport;
    jEditbox=jViewPort.getComponent(0);
    %set(jScrollPane,'HorizontalScrollBarPolicy', jScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
    %set(jScrollPane,'VerticalScrollBarPolicy', jScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
    set(jScrollPane,'HorizontalScrollBarPolicy', 32);
    %set(jScrollPane,'VerticalScrollBarPolicy', 22);
    jEditbox.setWrapping(false);
 
 set(b1_ref,'String','Choose source files');
 set(b2_ref,'String','Create images');
 set(st1_ref,'String','Edit box','HorizontalAlignment','left');

 set(h_edit1,'FontSize',12);
 set(t_ref,'FontSize',12);
 
%     for i=1:4
%     h=findobj('Tag', strcat('edit',int2str(i)));
%     set(h,'HorizontalAlignment','left','Max',3,'String','');    
%     jScrollPane=findjobj(h);
%     jViewPort=jScrollPane.getViewport;
%     jEditbox=jViewPort.getComponent(0);
%     %set(jScrollPane,'HorizontalScrollBarPolicy', jScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
%     %set(jScrollPane,'VerticalScrollBarPolicy', jScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
%     set(jScrollPane,'HorizontalScrollBarPolicy', 32);
%     %set(jScrollPane,'VerticalScrollBarPolicy', 22);
%     jEditbox.setWrapping(false);
%     end
    set(t_ref,'ColumnName',{'Source files','Result folders','Type of file','Frequencies', ...
        't_column','W_column','Wavelets','Additional graphics','t_min','t_max','omega_min', ...
        'omega_max','Row_min','Row_max','Row_step'});
    
    Cols=[1,4,2,5,6,7,9,10,11,12,13,14,15,8,3];

    data=repmat({''},jt_ref.getRowCount(),jt_ref.getColumnCount());
    i=numel(get(t_ref,'ColumnName'));
    %columnformat = {'text', 'text', 'text'};
    %columneditable = [true true true]; 
    set(t_ref,'ColumnEditable',true(1,i),'ColumnFormat',repmat({'char'},1,i));%,'ColumnWidth','auto');
 set(t_ref,'Data',data);
 
%disp(prm('t_view(5.7::7]'));
 % jScrollPane.getcolumn(1).setEditable(1);
    
% mtable = uitable('Parent',gcf,);
% jUIScrollPane = findjobj(mtable);
% jUITable = jUIScrollPane.getViewport.getView;
% row = jUITable.getSelectedRow + 1; % Java indexes start at 0
% col = jUITable.getSelectedColumn + 1;


%     jUIScrollPane=findjobj(h);
%     jUITable=jUIScrollPane.getViewport.getView;
%       jUITable.getColumnExt(1).setEditable(true);
    
    %uitable:
    %set(t, 'columnname', {'X', 'Y', 'Z', 'T'});
    
% --- Outputs from this function are returned to the command line.
function varargout = Wavelet_images_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;



function edit1_Callback(hObject, eventdata, handles)
% hObject    handle to edit1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of edit1 as text
%        str2double(get(hObject,'String')) returns contents of edit1 as a double


% --- Executes during object creation, after setting all properties.
function edit1_CreateFcn(hObject, eventdata, handles)
% hObject    handle to edit1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end



function edit2_Callback(hObject, eventdata, handles)
% hObject    handle to edit2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of edit2 as text
%        str2double(get(hObject,'String')) returns contents of edit2 as a double


% --- Executes during object creation, after setting all properties.
function edit2_CreateFcn(hObject, eventdata, handles)
% hObject    handle to edit2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end



function edit3_Callback(hObject, eventdata, handles)
% hObject    handle to edit3 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of edit3 as text
%        str2double(get(hObject,'String')) returns contents of edit3 as a double


% --- Executes during object creation, after setting all properties.
function edit3_CreateFcn(hObject, eventdata, handles)
% hObject    handle to edit3 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end

% --- Executes on button press in pushbutton1.
function pushbutton1_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

global t_ref jt_ref


% input ~ Request user input
% uiimport ~ Open Import Wizard to import data

 %h=findobj('Tag','edit1');

 
 
 
%  choice = strcmp(questdlg('Will you select target files or file list of them?', ...
%     'File type request', 'Target files', 'File list', 'Target files'),'Target files');
% 
% if choice
%     % Target files:
% [list,ipath]=uigetfile({'*.*','All files (*.*)'}, ...
%     'Select input file(s):','MultiSelect','on');
%  %list=cellstr(strcat(ipath,list));
% else
%     % File list:
%     [file,ipath]=uigetfile({'*.*','All files (*.*)'}, ...
%     'Select file list of target files:','MultiSelect','off');
% %list=cellstr(list);
%  [fid,msg]=fopen(char(strcat(ipath,file))); 
%  list = textscan(fid, '%s', 'delimiter', '\n');
%  list=list{1};
%  fclose(fid);
% end
 
 [list,ipath]=uigetfile('*.*','MultiSelect','on');
 
 
 
% if strcmp(get(h_edit1,'String'),'')==0
%  set(h_edit1,'String',vertcat(cellstr(get(h_edit1,'String')),cellstr(strcat(ipath,list))'));
% else
%  set(h_edit1,'String',cellstr(strcat(ipath,list))');   
% end  
% if strcmp(get(h_edit3,'String'),'')==0 
%  set(h_edit3,'String',vertcat(cellstr(get(h_edit3,'String')),cellstr(repmat(ipath,numel(cellstr(list)),1))));
% else
%  set(h_edit3,'String',cellstr(repmat(ipath,numel(cellstr(list)),1)));   
% end
% if strcmp(get(h_edit4,'String'),'')==0 
%  set(h_edit4,'String',vertcat(cellstr(get(h_edit4,'String')),cellstr(repmat('0',numel(cellstr(list)),1))));
% else
%  set(h_edit4,'String',cellstr(repmat('0',numel(cellstr(list)),1)));   
% end
if ~isnumeric(list)
 data=getdata(t_ref,jt_ref);
 i=1;
while i<=size(data,1) & ~strcmp(data(i,1),'') 
 i=i+1;
end
if size(data,1)-i<size(list,2)
    data(size(list)+i,1)={''};
end
 set(t_ref,'Data',horzcat(cellstr(strcat(ipath,list))',cellstr(repmat(ipath,numel(cellstr(list)),1))));
end 
 %drawnow;
 
 %columneditable = true(1,numel(get(t_ref,'ColumnName')));
 %set(t_ref,'Data',cellstr(get(h_edit1,'String')),'ColumnWidth','auto','ColumnEditable',columneditable);
   
    %columneditable = [true true true]; 

 %c=textscan(get(h,'String'), '%s', 'Delimiter', sprintf('\f'));

 
 %disp(numel(edit1_list));
 %s=textscan(edit1_list{1},'%s','Delimiter',' ','MultipleDelimsAsOne',1);
 %disp(s{1}(2));
 %disp(numel(s{1}));

 %set(findobj('Tag','edit2'),'String',s);
%cellfun



% --- Executes during object creation, after setting all properties.
function figure1_CreateFcn(hObject, eventdata, handles)
% hObject    handle to figure1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called


% --- Executes when figure1 is resized.
function figure1_ResizeFcn(hObject, eventdata, handles)
% hObject    handle to figure1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global h_edit1 main_figure t_ref b1_ref b2_ref b3_ref b4_ref st1_ref
resize_ui(t_ref,main_figure);
resize_ui(h_edit1,main_figure);
resize_ui(st1_ref,main_figure);
resize_ui(b1_ref,main_figure);
resize_ui(b2_ref,main_figure);
resize_ui(b3_ref,main_figure);
resize_ui(b4_ref,main_figure);

%==========================================================================
function link_ui(ui_ref,parent_ref,links)
 link1=regexp(lower(links),',','split');
 mf_pos=get(parent_ref,'Position');
 p=get(ui_ref,'Position');
 ui_diff=[0,0,0,0];
for i=1:size(link1,2) 
  switch char(link1(i))
      case 'left'
          ui_diff(1)=p(1);
      case 'right'
          ui_diff(2)=mf_pos(3)-p(3)-p(1);
      case 'top'
          ui_diff(3)=mf_pos(4)-p(2)-p(4);
      case 'bottom'
          ui_diff(4)=p(2);
  end
end
 set(ui_ref,'UserData',ui_diff);

function resize_ui(ui_ref,parent_ref)
 mf_pos=get(parent_ref,'Position');
 p=get(ui_ref,'Position');
 ui_diff=get(ui_ref,'UserData');
if numel(ui_diff)~=0
if ui_diff(1)==0 & ui_diff(2)~=0 % right
 p(1)=mf_pos(3)-ui_diff(2)-p(3);
end
if ui_diff(1)~=0 & ui_diff(2)~=0 % left & right
 p(3)=mf_pos(3)-ui_diff(2)-p(1);
end

if ui_diff(3)~=0 & ui_diff(4)==0 % top
 p(2)=mf_pos(4)-ui_diff(3)-p(4);
end
if ui_diff(3)~=0 & ui_diff(4)~=0 % top & bottom
 p(4)=mf_pos(4)-ui_diff(3)-p(2);
end
 set(ui_ref,'Position',p);
end

function tmp_data=getdata(table_ref,jtable_ref)
 data=get(table_ref,'Data');
 %tmp_data=cell(numel(get(table_ref,'RowName')),numel(get(table_ref,'ColumnName')));
 tmp_data=repmat({''},jtable_ref.getRowCount(),jtable_ref.getColumnCount());
% for i=1:size(tmp_data,1) 
%     for j=1:size(tmp_data,2)
%         tmp_data(i,j)={''};
%     end
% end 

for i=1:size(data,1)
    for j=1:size(data,2)
        tmp_data(i,j)=data(i,j);
    end
end

function res = drv(x,col,dt)
 l=size(x,col);
 res=x(:,col);
 res(1)=(x(3,col)-x(1,col))/(2*dt);
for i=2:l-1
 res(i)=(x(i+1,col)-x(i-1,col))/(2*dt);
end
 res(l)=res(l-1);

function res = drv2(x,col,dt)
 l=size(x,col);
 res=x(:,col);
 res(1)=(x(3,col)-2*x(2,col)+x(1,col))/(2*dt);
for i=2:l-1
 res(i)=(x(i+1,col)-2*x(i,col)+x(i-1,col))/(2*dt);
end
 res(l)=res(l-1);
 
function res=round1(x,y)
 res=fix(x*power(10,y))/power(10,y);

function res=prm(s) 
 i=strfind(s,'(');
 include1=false;
if isempty(i)
 i=strfind(s,'[');
 include1=true;
end
 j=strfind(s,')');
 include2=false;
if isempty(j)
 j=strfind(s,']');
 include2=true;
end
 res=horzcat(s(1:i-1),regexp(s(i+1:j-1),':','split'),include1,include2);
 
function wvl()
global Cols t_ref jt_ref
%duffing combined plot
%paramaters
%управл€ющие параметры

%wvls={'gaus32';'morl'};
%wvls={'morl'};
fmt='-djpeg';
fmt_ext='.png';
file_type={'text'};
t_col=1;
w_col=2;
d2=true;
d3=false;
spektr=false;
signal=false;
phase_picture=false;
puankare=false;
wvls={'2D','morl'};
t_min=0;
t_max=1000;
omega_min=0.05;
omega_max=12;
r_min=1;
r_max=0;
r_step=1;

data=getdata(t_ref,jt_ref);

if strcmp(data(1,Cols(15)),'') %file type
 data(1,Cols(15))=file_type;
end

if strcmp(data(1,Cols(4)),'') %t_col
    data(1,Cols(4))=cellstr(num2str(t_col));
end

if strcmp(data(1,Cols(5)),'') %W_col
    data(1,Cols(5))=cellstr(num2str(w_col));
end

if strcmp(data(1,Cols(6)),'') %wvls
 data(1,Cols(6))={''};
for i=1:numel(wvls)-1    
 data(1,Cols(6))=strcat(data(1,Cols(6)),wvls(i),',');
end 
 data(1,Cols(6))=strcat(data(1,Cols(6)),wvls(numel(wvls)));
end 

if strcmp(data(1,Cols(7)),'') %t_min
    data(1,Cols(7))=cellstr(num2str(t_min));
end

if strcmp(data(1,Cols(8)),'') %t_max
    data(1,Cols(8))=cellstr(num2str(t_max));
end

if strcmp(data(1,Cols(9)),'') %omega_min
    data(1,Cols(9))=cellstr(num2str(omega_min));
end

if strcmp(data(1,Cols(10)),'') %omega_max
    data(1,Cols(10))=cellstr(num2str(omega_max));
end

if strcmp(data(1,Cols(11)),'') %r_min
    data(1,Cols(11))=cellstr(num2str(r_min));
end

if strcmp(data(1,Cols(12)),'') %r_max
    data(1,Cols(12))=cellstr(num2str(r_max));
end

if strcmp(data(1,Cols(13)),'') %r_step
    data(1,Cols(13))=cellstr(num2str(r_step));
end

 set(t_ref,'Data',data);


if ~strcmp(data(1,Cols(1)),'') & ~strcmp(data(1,Cols(2)),'') & ...
        ~strcmp(data(1,Cols(3)),'') % Are enough values specified?

%for tn=1:size(data,1);
 tn=1;
while tn<=size(data,1) & ~strcmp(data(tn,1),'')
    
if ~strcmp(data(tn,Cols(15)),'') %file type
 file_type=regexp(char(data(tn,Cols(15))),',','split');
end
    
if ~strcmp(data(tn,Cols(2)),'')
    s.omega_init=str2double(data(tn,Cols(2))); 
end

if ~strcmp(data(tn,Cols(4)),'')
    t_col=str2double(data(tn,Cols(4))); 
end

if ~strcmp(data(tn,Cols(5)),'')
    w_col=str2double(data(tn,Cols(5))); 
end

if ~strcmp(data(tn,Cols(6)),'') %wvls
 wvls=regexp(char(data(tn,Cols(6))),',','split');
end

if ~strcmp(data(tn,Cols(7)),'') %t_min
    t_min=str2double(data(tn,Cols(7)));
end

if ~strcmp(data(tn,Cols(8)),'') %t_max
    t_max=str2double(data(tn,Cols(8)));
end

if ~strcmp(data(tn,Cols(9)),'') %omega_min
    omega_min=str2double(data(tn,Cols(9)));
end

if ~strcmp(data(tn,Cols(10)),'') %omega_max
    omega_max=str2double(data(tn,Cols(10)));
end

if ~strcmp(data(tn,Cols(11)),'') %r_min
    r_min=str2double(data(tn,Cols(11)));
end

if ~strcmp(data(tn,Cols(12)),'') %r_max
    r_max=str2double(data(tn,Cols(12)));
end

if ~strcmp(data(tn,Cols(13)),'') %r_step
    r_step=str2double(data(tn,Cols(13)));
end

%if ~strcmp(data(tn,Cols(14)),'') %Additional graphics
    adds=regexp(char(data(tn,Cols(14))),',','split');
%end

s.omega_max=s.omega_init;
%s.omega_max=3;%
%s.omega_step=0.23;
s.omega=s.omega_init;

%if data()

% wvls={'db1';'db2';'db3';'db4';'db5';'db6';'db7';'db8';'db9';'db10';
%  'sym2';'sym3';'sym4';'sym5';'sym6';'sym7';'sym8'; 
%  'coif1';'coif2';'coif3';'coif4';'coif5';
%  'meyr';
%  'gaus1';'gaus2';'gaus3';'gaus4';'gaus5';'gaus6';'gaus7';'gaus8';
%  'mexh'; 
% % 'morl';
% %
% 'shan1-1.5';'cmor';'bior';'rbio';'sym2';'sym3';'sym4';'sym5';'sym6';'sym7';'sym8';'coif1';'coif2';'coif3';'coif4';'coif5';
% };

%wvls={'morl';'cmor1-1.5';'gaus32';'cgau32'};
 %wvls={'db1';'db3';'db5';'db6';'db8';'sym2';'sym3';'sym4';'sym5';'sym6';'sym7';'sym8';'coif1';'coif2';'coif3';'coif4';'coif5'};
%wvls={'meyr';
   % 'morl';
   % 'mexh';
   % 'gaus1';'gaus2';'gaus3';'gaus4';'gaus5';'gaus6';'gaus7';'gaus8';
   % 'db1';'db2';'db3';'db4';'db5';'db6';'db7';'db8';'db9';
   % 'sym2';'sym3';'sym4';'sym5';'sym6';'sym7';'sym8'
   % 'coif1';'coif2';'coif3';'coif4';'coif5';
   % 'shan1-1.5';'shan1-1';'shan1-0.5';'shan1-0.1';'shan2-3';
   % 'cmor1-1.5';'cmor1-1';'cmor1-0.5';'cmor1-0.1';
    %'bior1.1';'rbio1.1';'bior2.2';'rbio2.2';'bior3.3';'rbio3.3';'bior4.4';'rbio4.4';'bior5.5';'rbio5.5';'bior6.8';'rbio6.8';};
%  wvls={'cmor1-1.5'};
% wvls={'cmor1-1.5';'cmor1-1';'cmor1-0.5';'cmor1-0.1'};
% wvls={'cmor1-0.1'};
% wvls={'cmor1-1'};
% while ((s.omega - s.omega_max)<1e-10)


%----      s.Q01=s.Q01_init;

      
      % wvls={'morl'};


%----while ((s.Q01 - s.Q01_max)<=1e-10)
%      fname_t=strcat('Output1','_','Q01','_');
%----     fname_t=strcat('w307453_a','_');
%      beam='signal_kusok4_50000';
%----     fname_t=strcat(fname_t,sprintf('%.0f',s.Q01));  
%----     fname_att=strcat(ipath,fname_t);
%----     tmp=load(fname_att);
  [source_path,source_name,source_ext]=fileparts(char(data(tn,Cols(1))));
     %tmp=dlmread(char(data(tn,Cols(1))),'',0,0); %textscan
       disp(char(data(tn,Cols(1))));   
switch char(file_type(1)) % file_type can be: 'text' or 'single,40' or 'double,120' etc.
    case 'text'
     fid=fopen(char(data(tn,Cols(1))));
     
     if t_col-1>0
         pattern=strcat(repmat(' %*f ',1,t_col-1),' %f ');
     else
         pattern=' %f ';
     end
     if w_col-t_col-1>0
         pattern=char(strcat(pattern,repmat(' %*f ',1,w_col-t_col-1),' %f %*[^\n]'));
     else
         pattern=char(strcat(pattern,' %f %*[^\n]'));
     end
      %disp(pattern);
     tmp = cell2mat(textscan(fid, pattern));

    case 'single'
        fid=fopen(char(data(tn,Cols(1))),'rb');
        tmp=fread(fid,[str2double(file_type(2)),inf],'*single')';
        tmp=tmp(:,t_col:w_col-t_col:w_col);
    case 'double'
        fid=fopen(char(data(tn,Cols(1))),'rb');
        tmp=fread(fid,[str2double(file_type(2)),inf],'*double')'; 
        tmp=tmp(:,t_col:w_col-t_col:w_col);
end
     fclose(fid);

     has_nan=isnan(tmp);
     for i=1:size(has_nan,1)
         for j=1:2
             if has_nan(i,j)
                 fprintf('!!! NAN found at row=%d column=%d of result array\n',i,j);
             end
         end
     end
     
     
     tmp1=tmp(1:1:end,:);
     dt=tmp1(2,1)-tmp1(1,1);
%      tmp=tmp(round(300/dt):round(400/dt),:);
%       tmp=tmp(round(300/dt):round(400/dt),:);
     t_w=tmp1(1:1:size(tmp1,1),1);
     w1_w=tmp1(1:1:size(tmp1,1),2);  
     dt_w=t_w(2)-t_w(1);
     
  
        if ~strcmp(data(tn,Cols(7)),'')
        t_1=str2double(char(data(tn,Cols(7))));
        end
        
        if ~strcmp(data(tn,Cols(8)),'')
        t_2=str2double(char(data(tn,Cols(8))));
        end
% -------------------------------------------
         if t_1<t_w(1,1)
         t_1=t_w(1,1);
         end
         if t_2>t_w(end,1)
         t_2=t_w(end,1);
         end
% -------------------------------------------
     
     
for i=1:length(wvls)
    switch lower(char(wvls(i)))
        case '2d'
            d2=true;
        case '3d'
            d3=true;
        case '-2d'
            d2=false;
        case '-3d'
            d3=false;
        otherwise
            if d2 | d3

                wvl_type=char(wvls(i));
%         min_omega=omega_min;
%         max_omega=omega_max;
        min_f=omega_min/(2*pi);
        max_f=omega_max/(2*pi);
        iter=10;
        max_scale=centfrq(wvl_type,iter)/(min_f*dt_w);
        min_scale=centfrq(wvl_type,iter)/(max_f*dt_w);        
        %defining wavelet scales
%         lss=0.05;
        lss=0.05;
        log_scale_step=lss;
        lss_factor=pow2(log_scale_step);
        scales(1,1)=min_scale;
        k=1;
        curr_scale=[];
        while scales(1,k)<=max_scale            
          curr_scale=scales(1,k)*lss_factor;
          k=k+1;
          scales(1,k)=curr_scale;
        end
        
%         scales=min_scale:1:max_scale;
        wvl_coeffs=cwt(w1_w,scales,wvl_type); 
        %wvl_coeffs_ud=flipud(wvl_coeffs);
        abs_c=abs(wvl_coeffs);
      
       %scales to frequencies transformation
        pffreqs=zeros(1,size(scales,2));
        for k=1:(size(scales,2))
        pffreqs(1,k)=1/scales(1,k);
        end
        pffreqs=centfrq(wvl_type,iter)*(1/dt_w)*pffreqs;
        pffreqs=pffreqs.*2.*pi;% for equation with omega*t as argument 
        pffreqs=fliplr(pffreqs);
        abs_c=flipud(abs_c);
        
       %amplifying
       
%        ampl=ones(size(abs_c,1),1);
%          for n=1:size(abs_c,1)
% %             ampl(n,1)=10-9*(pffreqs(n)-pffreqs(1))/(pffreqs(end)-pffreqs(1));
% %        ampl(n,1)=1/(pffreqs(n)-pffreqs(1)+1)^(1.5);
%          ampl(n,1)=1/(pffreqs(n)-pffreqs(1)+1)^(1);
% %               ampl(n,1)=1;
%          end 
%         for n=1:size(abs_c,1)
%             for m=1:size(abs_c,2)          
%             abs_c(n,m)=ampl(n)*abs_c(n,m);
%             end      
%         end
            end
% =========================================================================
   if d2 % t_1,t_end
    disp(sprintf('2D %s',char(wvls(i))));
if exist(strcat(char(data(tn,Cols(3))),'2Dpffreqs\',char(wvls(i))),'dir')~=7
    mkdir(strcat(char(data(tn,Cols(3))),'2Dpffreqs\',char(wvls(i))));
end
        %2D plot (pcolor plot with scales converted to pseudofrequencies)
%         figure('Name','2D_pf');
        q_w2=1;
        %прореживание
        t_w2=t_w(1:q_w2:end,1);
        pffreqs_w2=pffreqs(1,1:1:end);
        abs_c_w2=abs_c(1:1:end,:);
        abs_c_w2=abs_c_w2(:,1:q_w2:end); 

        %cutting a window
        dt_w2=t_w2(2,1)-t_w2(1,1);
        

        
        n2D_t_1=round((t_1-t_w2(1,1))/dt_w2)+1; n2D_t_2=round((t_2-t_w2(1,1))/dt_w2);
        
        t_w2=t_w2(n2D_t_1:n2D_t_2,1);
        abs_c_w2=abs_c_w2(:, n2D_t_1:n2D_t_2);        
       
        cf_handle=figure();
        
        % Minimize window:
        jFrame = get(handle(cf_handle),'JavaFrame');
        pause(0.1);  % <- This is important
        jFrame.setMinimized(true);
        
        gca_tmp=gca(cf_handle);
        
        pcolor(gca_tmp,t_w2,pffreqs_w2,abs_c_w2); 
        colormap(gca_tmp,pink);
        shading(gca_tmp,'interp');
%         caption_wavelet2D=strcat(source_name,'_',wvl_type,'_2Dwavelet');        
%         title(caption_wavelet2D,'Interpreter','none');
        set(gca_tmp,'fontsize',26);
        
        set(gca_tmp,'TickDir','out');

%         xlabel('t');
%         ylabel('\omega');
%        set(get(gca,'YLabel'),'Rotation',0);

%-----------------------------------------------------
%      text(1,0,'t','Units','Normalized','fontsize',48);
%      text(0,1,'\omega','Units','Normalized','fontsize',48, ...
%          'HorizontalAlignment','Center','VerticalAlignment','Bottom');         
%-----------------------------------------------------



%         %window for real wavelets
%         %define window now, plot later
%         n_t_center=round(size(t_w,1)/2);
% %        wa=size(t_w,1)-round(8400/dt_w); wb=size(t_w,1)-round(7900/dt_w); 
%         wa=n_t_center-round(25/dt_w);wb=n_t_center+round(25/dt_w);
%         window=wa:wb;        
        %window for cmor wavelets
        %define window now, plot later
%         n_t_center=round(size(t_w,1)/2);
%        wa=size(t_w,1)-round(8400/dt_w); wb=size(t_w,1)-round(7900/dt_w); 
%         wa=n_t_center-round(75/dt_w);wb=n_t_center+round(75/dt_w);
%         wa=1; wb=size(t_w,1);
%         window=wa:wb;        

% %show window's borders
%         win_borders=[t_w2(wa),pffreqs_w2(1),t_w2(wb)-t_w2(wa),pffreqs_w2(end)-pffreqs_w2(1)];
%         rectangle('Position',win_borders,'EdgeColor','green','LineWidth',2);        
        out_path_wavelet2D=strcat(char(data(tn,Cols(3))),'2Dpffreqs\\');
        fplotname_wavelet2D=strcat(out_path_wavelet2D,'\\',wvl_type,'\',source_name,'_',wvl_type,'_2Dwavelet_',...
        sprintf('%.0f',t_1),'_',sprintf('%.0f',t_2));
%         set(gcf, 'PaperPositionMode', 'manual');
%         set(gcf, 'PaperUnits', 'centimeters');
%         h=3.66;w=4.64;
%         set(gcf,'PaperSize',[h w]);
%         set(gcf, 'PaperPosition', [0 0  w h]);

       
%         print(cf_handle,fmt,'-zbuffer',strcat(fplotname_wavelet2D,fmt_ext));

        saveas(cf_handle,strcat(fplotname_wavelet2D,fmt_ext));
       saveas(cf_handle,strcat(fplotname_wavelet2D,'.fig'),'fig');

      % emf: saveas(cf_handle,strcat(fplotname_wavelet2D,'.emf'),'emf');
        
        
%         %2D plot window (pcolor plot with scales converted to pseudofrequencies)
%         figure('Name','2D_pf_window');
%         q_w2_1=1;
%         %прореживание
%         t_w2_1=t_w(1:q_w2_1:end,1);
%         pffreqs_w2_1=pffreqs(1,1:1:end);
%         abs_c_w2_1=abs_c(1:1:end, :);
%         abs_c_w2_1=abs_c_w2_1(:, 1:q_w2_1:end); 
%         caption_wavelet2D_1=strcat(inp_fname,'_',wvl_type,'_2Dwavelet_window');
% %         %define window now, plot later
% %         n_t_center=round(size(t_w,1)/2);
% % %       wa=size(t_w,1)-round(8400/dt_w); wb=size(t_w,1)-round(7900/dt_w); 
% %         wa=n_t_center-round(25/dt_w);wb=n_t_center+round(25/dt_w);
% %         window=wa:wb;        
%        
%         t_w2_1_win=t_w2_1(window,:);
%         abs_c_w2_1_win=abs_c_w2_1(:,window);
%         pcolor(t_w2_1_win,pffreqs_w2_1,abs_c_w2_1_win); 
%         colormap pink;
%         shading interp;
% %         title(caption_wavelet2D_1,'Interpreter','none');
%         xlabel('t');
%         ylabel('\omega');
%         set(get(gca,'YLabel'),'Rotation',0);
%         out_path_wavelet2D_1=strcat(opath,'wavelet\\2Dpffreqs\\');
%         fplotname_wavelet2D_1=strcat(out_path_wavelet2D_1,wvl_type,'\\',wvl_type,'_',inp_fname,'_2Dwavelet_window','.emf');
%         print(gcf,'-dmeta',fplotname_wavelet2D_1);
%         fplotname_wavelet2D_1=strcat(out_path_wavelet2D_1,wvl_type,'\\',wvl_type,'_',inp_fname,'_2Dwavelet_window','.eps');
%         print(gcf,'-depsc',fplotname_wavelet2D_1);


%  %2D phase plot (pcolor plot with scales converted to pseudofrequencies)
% 
%  figure('Name','2D_pf phase');
%         q_w_ph=1;
%         %прореживание
%         t_w_ph=t_w(1:q_w_ph:end,1);
%         pffreqs_w_ph=pffreqs(1,1:1:end);
%         phase = angle(wvl_coeffs);
%         phase=flipud(phase);
%         phase=phase(1:1:end, :);
%         phase=phase(:, 1:q_w_ph:end);  
%         %define window
% %         n_t_center=round(size(t_w,1)/2);
% % %         wa=size(t_w,1)-round(8400/dt_w); wb=size(t_w,1)-round(7900/dt_w); 
% %         wa=n_t_center-round(75/dt_w);wb=n_t_center+round(75/dt_w);
% %        wa=1;wb=size(t_w,1);
%         window=wa:wb;        
%        t_phase_win=t_w_ph(window,:);
%         phase_win=phase(:,window);
%         pcolor(t_phase_win,pffreqs_w_ph,phase_win); 
%         set(gca,'TickDir','out');
%         cm2d='pink';
%         colormap(cm2d);
%         shading interp;
%         set(gca,'TickDir','out');
%         set(gca,'fontsize',20);
%         xlabel('t');
%         ylabel('\omega');     
%         set(get(gca,'YLabel'),'Rotation',0);
%         caption_wavelet2D_phase=strcat(inp_fname,'_',wvl_type,'_2Dwavelet_phase');       
% %         title(caption_wavelet2D_phase,'Interpreter','none');
%         %plotting window
% %         hold on
% %         annotation('rectangle',[wa 0 wb-wa pffreqs_w2(end)-pffreqs_w2(1) ])
% %         hold off
%         out_path_wavelet2D_phase=strcat(opath,'wavelet\\phase\\2D\\');
%         fplotname_wavelet2D_phase=strcat(out_path_wavelet2D_phase,wvl_type,'\\',wvl_type,'_',inp_fname,'_2Dwavelet_phase','.emf');
%         %fplotname2=strcat(out_path2,wvl_type,'_','pffreqs(num)','_',sprintf('%1.1f',omega),'_',sprintf('%5.0f',q0));
%         dummy=1;
% %         set(gcf, 'PaperPositionMode', 'manual');
% %         set(gcf, 'PaperUnits', 'centimeters');
% %         h=3.66;w=4.64;
% %         set(gcf,'PaperSize',[h w]);
% %         set(gcf, 'PaperPosition', [0 0  w h]);
%         print(gcf,'-dmeta', fplotname_wavelet2D_phase);
%       
        %3D plot (pcolor plot with scales converted to pseudofrequencies)
         close(cf_handle);
    end
% =========================================================================         
         if d3
        disp('3D');
if exist(strcat(char(data(tn,Cols(3))),'3Dpffreqs\',char(wvls(i))),'dir')~=7
    mkdir(strcat(char(data(tn,Cols(3))),'3Dpffreqs\',char(wvls(i))));
end        
         cf_handle=figure('Name','3D_pf');
         
        % Minimize window:
        jFrame = get(handle(cf_handle),'JavaFrame');
        pause(0.1);  % <- This is important
        jFrame.setMinimized(true);
        
        gca_tmp=gca(cf_handle);
        set(gca_tmp,'fontsize',20);
%         прореживание дл€ построени€ поверхности
        q_w3=1; %прореживание  %w1=w1(1:10:end, 1:10:end);
        t_w3=t_w(1:q_w3:end,1);
        pffreqs_w3=pffreqs(1,1:end);       
        abs_c_w3=abs_c(1:1:end, :);
        abs_c_w3=abs_c_w3(:, 1:q_w3:end);
%       cutting a window
        dt_w3=t_w3(2,1)-t_w3(1,1);
        
        % t_1=str2double(edit4_list{tn}); t_2=1000;
%         t_1=1; t_2=109;
        n3D_t_1=round((t_1-t_w2(1,1))/dt_w3)+1; n3D_t_2=round((t_2-t_w2(1,1))/dt_w3);
%         n3D_t_1=round(10/dt_w3); n3D_t_2=round(200/dt_w3);
        t_w3=t_w3(n3D_t_1:n3D_t_2,1);
        abs_c_w3=abs_c_w3(:, n3D_t_1:n3D_t_2); 
        %%%%%%%%%%%%%%%%%%%%%
        surf(gca_tmp,t_w3,pffreqs_w3,abs_c_w3); 
        axis(gca_tmp,[-Inf Inf -Inf Inf -Inf Inf])
%         mesh(t_w3,pffreqs_w3,abs_c_w3); 
        % set colormap
        cm='jet';
        colormap(gca_tmp,cm);
        caption_wavelet3D=strcat(source_name,'_',wvl_type,'_3Dwavelet');
        %surfl(t_w3,pffreqs_w3,abs_c_w3); 
        %axis([-Inf Inf -Inf Inf -10 Inf])
        %mesh(t_w3,pffreqs_w3,abs_c_w3);
         %view_angle = [32 24];
        % view_angle = [49 40];
       %   view_angle = [64 48];
       % view_angle = [90 0]; % эпюра мощности частот
        view_angle = [80 48]; 
        %view [50 20];
        view(gca_tmp,view_angle);  
        set(findobj(gca_tmp,'type','surface'),'EdgeColor','none','FaceLighting','phong');
        shading(gca_tmp,'interp');
%         camlight left
%       shading flat;
%        lightangle(view_angle(1),view_angle(2));    
%      set(gcf,'Renderer','zbuffer');
%      set(findobj(gca,'type','surface'),...
%     'FaceLighting','phong','FaceColor','interp','EdgeColor','none',...
%     'AmbientStrength',.3,'DiffuseStrength',.8,...
%     'SpecularStrength',.9,'SpecularExponent',25);
     title(gca_tmp,caption_wavelet3D,'Interpreter','none');
       
        xlabel(gca_tmp,'t','VerticalAlignment','middle');
        ylabel(gca_tmp,'\omega','VerticalAlignment','middle');
%         set(get(gca,'YLabel'),'Rotation',0);%     
        out_path_wavelet3D=strcat(char(data(tn,Cols(3))),'3Dpffreqs\\');       
%         fplotname_wavelet3D=strcat(out_path_wavelet3D,wvl_type,'\\',wvl_type,'_',inp_fname,'_3Dwavelet_','az=',num2str(view_angle(1)),'_','el=',num2str(view_angle(2)),'_',cm,'_','.eps');      
%         print(gcf,'-depsc',fplotname_wavelet3D);
        fplotname_wavelet3D=strcat(out_path_wavelet3D,wvl_type,'\\',source_name,'_',wvl_type,'_3Dwavelet_',...
        'az=',num2str(view_angle(1)),'_','el=',num2str(view_angle(2)),'_',cm,'_',...
        sprintf('%.0f',t_1),'_',sprintf('%.0f',t_2));      
% fplotname_wavelet2D=strcat(out_path_wavelet2D,'\\',wvl_type,'\',wvl_type,fname_t,'2Dwavelet','.emf');
        %set(gcf, 'PaperPositionMode', 'manual');
%         set(gcf, 'PaperUnits', 'centimeters');
%         h=3.66;w=4.64;
%         set(gcf,'PaperSize',[h w]);
%         set(gcf, 'PaperPosition', [0 0  w h]);
%         print(gcf,'-dmeta','-loose',  fplotname_wavelet3D);

%          print(cf_handle,fmt,'-zbuffer',strcat(fplotname_wavelet3D,fmt_ext));

         saveas(cf_handle,strcat(fplotname_wavelet3D,fmt_ext));
%         saveas(cf_handle,strcat(fplotname_wavelet3D,'.fig'),'fig');

   %     saveas(cf_handle,strcat(fplotname_wavelet3D,'.emf'),'emf');         
         close(cf_handle);
         end


    end
end
% =========================================================================
for i=1:length(adds)
  switch lower(char(adds(i)))
        case 'fft'
            spektr=true;
        case '-fft'
            spektr=false;
        case 'signal'
            signal=true;
        case '-signal'
            signal=false;
        case 'phase'
            phase_picture=true;
        case '-phase'
            phase_picture=false;
        case 'puan'
            puankare=true;
        case '-puan'
            puankare=false;
  end 
end
% =========================================================================
            if spektr %(t_min,t_max)
                   disp('Spectrum');
if exist(strcat(char(data(tn,Cols(3))),'FFT\'),'dir')~=7
    mkdir(strcat(char(data(tn,Cols(3))),'FFT\'));
end  
      fname_t=strcat(source_name,source_ext);   
%      fname_att=strcat(ipath,fname_t);
%      tmp=load(fname_att);
%      tmp=tmp(1:1:end,:);
%      dt=tmp(2,1)-tmp(1,1);

    % t_1=32; t_2=284;
     
%      tmp=tmp(end-round(410/dt):end,:);
%      tmp=tmp(round(500/dt):round(510/dt),:);
    % tmp=tmp(round(t_1/dt):round(t_2/dt),:);
%     dt=tmp(2,1)-tmp(1,1);      
     t=tmp(:,1);
     w=tmp(:,2);
     dt=t(2,1)-t(1,1);
     r1=find(t>t_min,1);
     r2=find(t<t_max,1,'last');
     w=w(r1:r2);
     
     fw1=fft(w);
     N1=length(fw1);
     fw1(1)=[];
     power1 = abs(fw1(1:fix(N1/2)));
     nyquist = 1/(2*dt);
% %         omega_nyquist= nyquist*2*pi;
     freq1 = 2*pi*nyquist*(1:N1/2)/(N1/2);
% %     figure('Name','frequency power spectrum w');
     power_plot1=log(power1);
% %         power_plot1=power1;
     cf_handle=figure('Name','Spektr Furier');
     
        jFrame = get(handle(cf_handle),'JavaFrame');
        pause(0.1);  %//This is important
        jFrame.setMinimized(true);
        
        gca_tmp=gca(cf_handle);
     
     plot(gca_tmp,freq1,power_plot1,'-','LineWidth',2,'Color','red');
% %          plot(freq1,power_plot1,'--','LineWidth',2);
% %         plot(freq1,power_plot1,':','LineWidth',2);
%     grid on;
% %         set(gca,'XTick',[1 2 3]);


%      axis(gca_tmp,[-Inf s.omega_init+1 -Inf Inf]);
     axis(gca_tmp,[-Inf 1.1*s.omega_init -Inf Inf]);
     set(gca_tmp,'fontsize',15);
%     caption_fourier_w=strcat('fourier_w_',fname_t);
%     title(caption_fourier_w);

%      xlabel('\omega','Units','normalized','Position',[1,0],'fontsize',24);
%      ylabel('F(\omega)','Units','normalized','Position',[0,1],'fontsize',24,'Rotation',0);

     fname_fourier_w=strcat(char(data(tn,Cols(3))),'fft\',fname_t,'_w_fourier_',sprintf('%.0f',t_min),...
     '_',sprintf('%.0f',t_max));
  
 %set(get(gca,'XLabel'),'String','axis label')
 
% set(get(gca,'XLabel'),'Units','data');
% set(get(gca,'YLabel'),'Units','data');

%      text(1,0,'\omega','Units','Normalized','fontsize',24);
%      text(0,1,'F(\omega)','Units','Normalized','fontsize',24, ...
%          'HorizontalAlignment','Center','VerticalAlignment','Bottom');

     saveas(cf_handle,strcat(fname_fourier_w,'.fig'),'fig');
     saveas(cf_handle,strcat(fname_fourier_w,fmt_ext));
%      print(cf_handle,fmt,'-zbuffer',strcat(fname_fourier_w,fmt_ext));
%      saveas(cf_handle,strcat(fname_fourier_w,'.emf'),'emf');
     grafik=[freq1',power_plot1];
     fid=fopen(char(strcat(fname_fourier_w,'.bin')),'w');
     fwrite(fid,grafik','single');
     fclose(fid);
     %dlmwrite(char(strcat(fname_fourier_w,'.txt')),grafik,' ');
%      save(char(strcat(fname_fourier_w,'.txt')),'grafik','-ascii','-double');
     close(cf_handle);
            end
% =========================================================================     
  if signal  %(t_min,t_max)
 disp('Signal');
if exist(strcat(char(data(tn,Cols(3))),'Signal\'),'dir')~=7
    mkdir(strcat(char(data(tn,Cols(3))),'Signal\'));
end  
     t=tmp(:,1);
     w=tmp(:,2);
 r1=find(t>t_min,1);
 r2=find(t<t_max,1,'last');
     t=t(r1:r2);
     w=w(r1:r2);
     
    cf_handle=figure('Name','Signal');
    
        jFrame = get(handle(cf_handle),'JavaFrame');
        pause(0.1);  %//This is important
        jFrame.setMinimized(true);
        
        gca_tmp=gca(cf_handle);
    
    plot(gca_tmp,t,w,'b-','Color','red');
%     plot(t,w,'LineWidth',2);

 
%disp([r1 r2]);
 axis(gca_tmp,[t_min t_max -Inf Inf]);
     %axis([t_min t_max min(w)-(max(w)-min(w))*0.1 max(w)+(max(w)-min(w))*0.1]);
%     axis auto;
     set(gca_tmp,'fontsize',15);
% %     legend('w');

%         xlabel('t','Units','pixels','Position',[450,15]);
%         ylabel('w(0.5,t)','Units','pixels','Position',[-35,350]);
        
 %    xlabel('t');
 %    ylabel('w');
%      set(get(gca,'YLabel'),'Rotation',0);
%      caption_signal_w=strcat('w_',fname_t);
   %  title(caption_signal_w);
    fname_t=strcat(source_name,source_ext);
    fname_signal_w=strcat(char(data(tn,Cols(3))),'signal\',fname_t,'_','signal','_',sprintf('%.0f',t_min), ...
     '_',sprintf('%.0f',t_max));

%      text(1,0,'t','Units','Normalized','fontsize',24,'VerticalAlignment','Bottom');
%      text(0,1,'w(0.5,t)','Units','Normalized','fontsize',24,'HorizontalAlignment','Center','VerticalAlignment','Bottom');

     %print(cf_handle,'-dmeta','-zbuffer',strcat(fname_signal_w,'.emf'));
%      print(cf_handle,fmt,'-zbuffer',strcat(fname_signal_w,fmt_ext));
     saveas(cf_handle,strcat(fname_signal_w,fmt_ext));
     saveas(cf_handle,strcat(fname_signal_w,'.fig'),'fig');
     close(cf_handle);
  end
% =========================================================================  
  if phase_picture % %(t_min,t_max)
    disp('Phase portrait');
if exist(strcat(char(data(tn,Cols(3))),'Phase portrait\'),'dir')~=7
    mkdir(strcat(char(data(tn,Cols(3))),'Phase portrait\'));
end        

     t=tmp(1:r_step:end,1);
     w=tmp(1:r_step:end,2);
     r1=find(t>t_min,1);
     r2=find(t<t_max,1,'last');
     w=w(r1:r2);
     dw=drv(w,1,dt_w*r_step);
     
    cf_handle=figure('Name','Phase portrait_2D');
    
        jFrame = get(handle(cf_handle),'JavaFrame');
        pause(0.1);  %//This is important
        jFrame.setMinimized(true);
        
        gca_tmp=gca(cf_handle);
    
    
    set(gca_tmp,'fontsize',15);    
  %  plot(w(1:end-1),diff(w)/dt_w,'b-','Color','red');
    plot(gca_tmp,w,dw,'b-','Color','red');
    fname_t=strcat(source_name,source_ext);
    fname_phase_w=strcat(char(data(tn,Cols(3))),'Phase portrait\',fname_t,'_','phase2D','_',sprintf('%.0f',t_min), ...
     '_',sprintf('%.0f',t_max));
    %print(cf_handle,'-dmeta','-zbuffer',strcat(fname_phase_w,'.emf'));
    
%     print(cf_handle,fmt,'-zbuffer',strcat(fname_phase_w,fmt_ext));
    saveas(cf_handle,strcat(fname_phase_w,fmt_ext));
    
%      grafik=[w,dw];
%      fid=fopen(char(strcat(fname_phase_w,'.bin')),'w');
%      fwrite(fid,grafik','single');
%      fclose(fid);

    %dlmwrite(char(strcat(fname_phase_w,'.txt')),grafik,' ');
    saveas(cf_handle,strcat(fname_phase_w,'.fig'),'fig');
    close(cf_handle);
%----------------------------------------------------
%     display([w dw drv(..dw,1,dt_w*r_step)]);
    cf_handle=figure('Name','Phase portrait_3D');
    
        jFrame = get(handle(cf_handle),'JavaFrame');
        pause(0.1);  %//This is important
        jFrame.setMinimized(true);
        
        gca_tmp=gca(cf_handle);
%     axis([-Inf Inf -Inf Inf -Inf Inf]);
%         view_angle = [80 48];
%         view(view_angle);
%         set(findobj(gca,'type','surface'),'EdgeColor','none','FaceLighting','phong');
%         shading interp;
    dw2=drv2(w,1,dt_w*r_step);
    plot3(gca_tmp,w(3:end-2),dw(3:end-2),dw2(3:end-2));%,'.');
    set(gca_tmp,'projection','perspective');
%     xlabel('$w$','fontsize',48,'interpreter','latex');
%     ylabel('$\dot{w}$','fontsize',48,'interpreter','latex');
%     zlabel('$\ddot{w}$','fontsize',48,'rotation',0,'interpreter','latex');
    grid(gca_tmp,'on');
    view(gca_tmp,[-39 71]);
    
     set(gca_tmp,'fontsize',15);
%      text(1,0,'t','Units','Normalized','fontsize',48);
%      text(0,1,'\omega','Units','Normalized','fontsize',48, ...
%          'HorizontalAlignment','Center','VerticalAlignment','Bottom');
    
    
    fname_t=strcat(source_name,source_ext);
    fname_phase_w=strcat(char(data(tn,Cols(3))),'Phase portrait\',fname_t,'_','phase3D','_',sprintf('%.0f',t_min), ...
     '_',sprintf('%.0f',t_max));
    %print(cf_handle,'-dmeta','-zbuffer',strcat(fname_phase_w,'.emf'));
%     print(cf_handle,fmt,'-zbuffer',strcat(fname_phase_w,fmt_ext));

     grafik=[w(3:end-2),dw(3:end-2),dw2(3:end-2)];
     fid=fopen(char(strcat(fname_phase_w,'.bin')),'w');
     fwrite(fid,grafik','single');
     fclose(fid);

%     saveas(cf_handle,strcat(fname_phase_w,fmt_ext));
    saveas(cf_handle,strcat(fname_phase_w,'.fig'),'fig');
    close(cf_handle);

  end
% =========================================================================  
  if puankare % r_min,r_max
      disp('Poincare mapping');
      
      k=32; % axes aspect ratio
      
if exist(strcat(char(data(tn,Cols(3))),'Puankare\'),'dir')~=7
    mkdir(strcat(char(data(tn,Cols(3))),'Puankare\'));
end        

if r_max==0
     t=tmp(r_min:r_step:end,1);
     w=tmp(r_min:r_step:end,2);
else
     t=tmp(r_min:r_step:r_max,1);
     w=tmp(r_min:r_step:r_max,2);
end
%      w=tmp(:,w_col);
%      r1=find(t>t_min,1);
%      r2=find(t<t_max,1,'last');
%      w=w(r1:r2);


     
     
% Variant 1 (cone.c)----------------------------------

 i=1;
 w_size=size(w,1);
 w_puan=zeros(w_size,2);
 w_puan(1,1)=w(1);
 t_pmax=t(1);
 period=2*pi/s.omega_init;
 round_signs=5;
 
while i<w_size && t(i)-t(1)<=period
if w(i)>w_puan(1,1)
    w_puan(1,1)=w(i);
    t_pmax=t(i);
end
 i=i+1;
end
 w_puan(1,1)=round1(w_puan(1,1),round_signs);

     j=1;
while i<w_size
    drob=(t(i)-t_pmax)/period;
    drob=drob-fix(drob);
    if drob<0.00001 || 1-drob<0.00001
        w_puan(j,2)=round1(w(i),round_signs);
        j=j+1;
        w_puan(j,1)=round1(w(i),round_signs);
    end
    i=i+1;
end
     w_puan(j:end,:)=[]; % Remove the rest of the dummy rows
     fprintf('Points found: %d\n',size(w_puan,1));
     
   cf_handle=figure('Name','Puankare');
   set(gca,'fontsize',15);    
   
   %   mn_x=min(w_puan(:,1));
   %   mx_x=max(w_puan(:,1));
   %   mn_y=min(w_puan(:,2));
   %   mx_y=max(w_puan(:,2));
   %   axis([mn_x-0.1*(mx_x-mn_x) mx_x+0.1*(mx_x-mn_x) mn_y-0.1*(mx_y-mn_y) mx_y+0.1*(mx_y-mn_y)]);
   
   w_puan=w_puan(2:end,:);
   %w_puan=mean(w_puan(2:end,:));
    
    plot(w_puan(:,1),w_puan(:,2),'r.','MarkerSize',30); % Color: red, marker: dot    
    %axis([auto auto min(w_puan,[],1) max(w_puan,[],1)]);
    axis equal;
    
    xlim=get(gca,'xlim');
    dx=xlim(1,2)-xlim(1,1);
    set(gca,'xlim',[xlim(1,1)-(k-1)*dx/2 xlim(1,2)+(k+1)*dx/2]);
    
    fname_t=strcat(source_name,source_ext);
    fname_puan_w=strcat(char(data(tn,Cols(3))),'Puankare\',fname_t,'_','puan','_', ...
        sprintf('%.0f',t_min),'_',sprintf('%.0f',t_max),'_k=',num2str(k)); 
    %print(cf_handle,'-dmeta','-zbuffer',strcat(fname_puan_w,'.emf')); 
    
    saveas(cf_handle,strcat(fname_puan_w,'.fig'),'fig');
    saveas(cf_handle,strcat(fname_puan_w,fmt_ext));
%     print(cf_handle,fmt,'-zbuffer',strcat(fname_puan_w,fmt_ext));

%     grafik=[w_puan(:,1),w_puan(:,2)];
%     save(char(strcat(fname_puan_w,'.txt')),'grafik','-ascii','-double');
        
    close(cf_handle);
  
% Variant 2 (simple pseudo) --------------------------

% j=0;
%  period=(2*pi)/s.omega_init;
%  w_size=size(w,1);
%  w_puan=zeros(w_size,2);
% % w_puan(0,0)=w(0);
% for i=1:w_size-1
%     if t(i)<=t(1)+j*period & t(i+1)>=t(1)+j*period
%         if t(1)+j*period-t(i)<=t(i+1)-(t(1)+j*period)
%             w_puan(j+1,2)=w(i);
%             j=j+1;
%             w_puan(j+1,1)=w(i);
%         else
%             w_puan(j+1,2)=w(i+1);
%             j=j+1;
%             w_puan(j+1,1)=w(i+1);
%         end
%     end
% end
%  w_puan(j+1:end,:)=[];
% 
% 
%    cf_handle=figure('Name','Puankare');
%    set(gca,'fontsize',15);    
% 
%    plot(w_puan(:,1),w_puan(:,2),'r.','MarkerSize',30); % Color: red, marker: dot    
%     fname_t=strcat(source_name,source_ext);
%     fname_puan_w=strcat(char(data(tn,Cols(3))),'Puankare\',fname_t,'_','puan','_', ...
%         sprintf('%.0f',t_min),'_',sprintf('%.0f',t_max));
%     %print(cf_handle,'-dmeta','-zbuffer',strcat(fname_puan_w,'.emf')); 
      
%     saveas(cf_handle,strcat(fname_puan_w,'.fig'),'fig');
%     saveas(cf_handle,strcat(fname_puan_w,fmt_ext));
%     %print(cf_handle,fmt,'-zbuffer',strcat(fname_puan_w,fmt_ext));
%     
%     %grafik=[w_puan(:,1),w_puan(:,2)];
%     %save(char(strcat(fname_puan_w,'.txt')),'grafik','-ascii');
%         
%     close(cf_handle);




    
     
% Variant 3 ------------------------------------------
%  j=0;
%      for i=2:(size(w,1)-1)
%          if w(i)>w(i-1) & w(i)>w(i+1) & (j==0 | w(i)>w(j))
%              j=i;
%          end
%      end
%      if j~=0
%           k=j;
%          if t(j)-(2*pi)/s.omega_init>=t(1) % max is to the right of start point
%           ti=t(j)-(2*pi)/s.omega_init;
%          %while k>1 && ~(t(k)<=ti && t(k-1)>=ti)
% %          if t(k)>ti
% %              disp('OK');
% %          end
%          while (k>1) & (t(k)>ti)
%              k=k-1;
%          end
%          if ti-t(k-1)<t(k)-ti
%              k=j-k+1;
%          else
%              k=j-k;
%          end
%          
%           w=w(j-k*fix(j/k):k:size(t,1));
%          else % max is start point
%           ti=t(j)+(2*pi)/s.omega_init;
%          %while k<size(t) && ~(t(k)<=ti && t(k+1)>=ti)
%          while k<size(t,1) & t(k)>ti & t(k+1)<ti
%              k=k+1;
%          end
%          if ti-t(k+1)<t(k)-ti
%              k=j-k-1;
%          else
%              k=j-k;
%          end
%          
%           w=w(j:k:size(t,1)); 
%          end
%          
%     cf_handle=figure('Name','Puankare');
%     set(gca,'fontsize',15);    
%   
%   
%     plot(w(1:end-1),w(2:end),'r.','MarkerSize',30); % Color: red, marker: dot
%     
%     fname_t=strcat(source_name,source_ext);
%     fname_puan_w=strcat(char(data(tn,Cols(3))),'Puankare\',fname_t,'_','puan','_',sprintf('%.0f',t_min), ...
%      '_',sprintf('%.0f',t_max));
%     %print(cf_handle,'-dmeta','-zbuffer',strcat(fname_puan_w,'.emf')); 
%     saveas(cf_handle,strcat(fname_puan_w,'.fig'),'fig');
%     saveas(cf_handle,strcat(fname_puan_w,fmt_ext));
%     %print(cf_handle,fmt,'-zbuffer',strcat(fname_puan_w,fmt_ext));
%     close(cf_handle);
%     
%      else
%          disp('!!!---- Error: Max not found. Poincare skipped'); %consider revising
%      end     


%      grafik=[w_puan(:,1),w_puan(:,2)];
     fid=fopen(char(strcat(fname_puan_w,'.bin')),'w');
     fwrite(fid,w_puan','single');
     fclose(fid);
  end
% =========================================================================  
 tn=tn+1;
end
 disp('All done =======================================================');
else
 errordlg('Not enough values specified','Error');   
end


% --- Executes on button press in pushbutton2.
function pushbutton2_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global main_figure main_figure_color jt_ref
 disp(strcat('[',get(hObject,'String'),'] pressed'));
 set(main_figure,'Color','Red');
 wvl;
 set(main_figure,'Color',main_figure_color);

%   t_ref1=findobj('Tag','uitable3');
%     jScrollPane1=findjobj(t_ref1);
%     jViewPort1=jScrollPane1.getViewport;
%     jt_ref1=jViewPort1.getComponent(0);
%     
%  jt_ref1.setValueAt(char('1'),1,1);
%  disp(jt_ref1.getValueAt(1,1));
    
    
% --- If Enable == 'on', executes on mouse press in 5 pixel border.
% --- Otherwise, executes on mouse press in 5 pixel border or over pushbutton2.
function pushbutton2_ButtonDownFcn(hObject, eventdata, handles)
% hObject    handle to pushbutton2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)



function edit4_Callback(hObject, eventdata, handles)
% hObject    handle to edit4 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of edit4 as text
%        str2double(get(hObject,'String')) returns contents of edit4 as a double


% --- Executes during object creation, after setting all properties.
function edit4_CreateFcn(hObject, eventdata, handles)
% hObject    handle to edit4 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end



function edit5_Callback(hObject, eventdata, handles)
% hObject    handle to edit5 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of edit5 as text
%        str2double(get(hObject,'String')) returns contents of edit5 as a double


% --- Executes during object creation, after setting all properties.
function edit5_CreateFcn(hObject, eventdata, handles)
% hObject    handle to edit5 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end


% --- Executes on button press in pushbutton3.
function pushbutton3_Callback(hObject, eventdata, handles) % <
% hObject    handle to pushbutton3 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
global h_edit1 t_ref jt_ref

% disp(jt_ref.getSelectedRows);
% disp('----');
% disp(jt_ref.getSelectedColumns);

%    set(t_ref,'ColumnEditable',true(1,numel(get(t_ref,'ColumnName'))));
%jt_ref.setValueAt('7',3,7);


 rows=jt_ref.getSelectedRows;
 cols=jt_ref.getSelectedColumns;
%  drawnow;
% disp(numel(get(t_ref,'RowName')));
% disp(numel(get(t_ref,'ColumnName')));
 
data1=getdata(t_ref,jt_ref);

 %data=data((1:numel(get(t_ref,'RowName'))),(1:numel(get(t_ref,'ColumnName'))));
 tmp=get(h_edit1,'String');
 i=1;
while i<=numel(rows) & i<=numel(tmp)
    s = regexp(char(tmp(i)),'\|','split');
    j=1;
    while j<=numel(cols) & j<=numel(s)
       % disp(s(j));
        data1(rows(i)+1,cols(j)+1)=s(j);
        %jt_ref.setValueAt(s(j),rows(i),cols(j));
        j=j+1;
    end
    i=i+1;
end
% drawnow;
%jt_ref.fireTableDataChanged();
 set(t_ref,'Data',data1);
%findjobj(gcf);

% s=jt_ref.getValueAt(0,0);
% disp(s);

% --- Executes on button press in pushbutton4.
function pushbutton4_Callback(hObject, eventdata, handles)  % >
% hObject    handle to pushbutton4 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

global h_edit1 t_ref jt_ref

% libpointer - Create pointer object for use with shared libraries
% ftp
% regexp
% waitbar - Open or update wait bar dialog box

% disp(jt_ref.getSelectedRows);
% disp('----');
% disp(jt_ref.getSelectedColumns);


 rows=jt_ref.getSelectedRows;
 cols=jt_ref.getSelectedColumns;

 %data=get(t_ref,'Data');
 tmp=cell(numel(rows),1);
for i=1:numel(rows)
    for j=1:numel(cols)-1
        tmp(i,1)=strcat(tmp(i,1),jt_ref.getValueAt(rows(i),cols(j)),'|'); 
    end
    tmp(i,1)=strcat(tmp(i,1),jt_ref.getValueAt(rows(i),cols(numel(cols))));
end
 set(h_edit1,'String',tmp);
