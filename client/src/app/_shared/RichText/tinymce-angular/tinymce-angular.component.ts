import { Component, OnInit } from '@angular/core';
import { EditorModule } from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-tinymce-angular',
  templateUrl: './tinymce-angular.component.html',
  styleUrls: ['./tinymce-angular.component.scss']
})
export class TinymceAngularComponent implements OnInit {

  editParam = {
    selector: 'textarea',
    mobile: {
      theme: 'silver',
      plugins: ['autosave', 'lists', 'autolink']
    },
    //// plugins是tinymce的各种插件
    plugins: `link lists image code table colorpicker fullscreen fullpage help
    textcolor wordcount contextmenu codesample importcss media preview print
    textpattern tabfocus hr directionality imagetools autosave paste`,
    // //语言包可以使用tinymce提供的网址,但是墙的原因,会连不上,所以还是自行下载,放到assets里面
    // language_url: '../../../assets/tinymce/langs/zh_CN.js',
    language: 'zh_CN',
    // //toolbar定义快捷栏的操作, | 用来分隔显示
    toolbar: 'undo redo  removeformat paste  bold italic underline strikethrough  | fontsizeselect |  forecolor backcolor | bullist numlist h2 h3 h4| '
      + ' link unlink image  | alignleft aligncenter alignright alignjustify outdent indent  |'
      + '  code blockquote fullscreen preview codesample  help',

    height: 300,
    // //这里是代码块的一些语言选择,好像暂时还没支持typescript,所以博文都是js格式
    // codesample_languages: [
    //   { text: 'HTML/XML', value: 'markup' },
    //   { text: 'JavaScript', value: 'javascript' },
    //   { text: 'CSS', value: 'css' },
    //   { text: 'Java', value: 'java' }
    // ],

    image_caption: true,
    // paset 插件允许粘贴图片
    paste_data_images: true,
    imagetools_toolbar: 'rotateleft rotateright | flipv fliph | editimage imageoptions',
    // 这个便是自定义上传图片方法
    images_upload_handler: function (blobInfo, success, failure) {
      let xhr, formData;
      xhr = new XMLHttpRequest();
      xhr.withCredentials = false;
      xhr.open('POST', '/api/upload');
      xhr.onload = function () {
        let json;
        if (xhr.status !== 200) {
          failure('HTTP Error: ' + xhr.status);
          return;
        }
        json = JSON.parse(xhr.responseText);
        if (!json || typeof json.location !== 'string') {
          failure('Invalid JSON: ' + xhr.responseText);
          return;
        }
        success(json.location);
      };
      formData = new FormData();
      formData.append('file', blobInfo.blob(), blobInfo.filename());
      xhr.send(formData);
    }
  };

  editData;

  constructor() { }

  ngOnInit(): void {
  }

}
