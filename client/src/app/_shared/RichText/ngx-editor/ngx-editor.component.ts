import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Editor, Toolbar } from 'ngx-editor';
import { schema } from 'ngx-editor/schema';
import { Plugin, PluginKey } from 'prosemirror-state';

@Component({
  selector: 'app-ngx-editor',
  templateUrl: './ngx-editor.component.html',
  styleUrls: ['./ngx-editor.component.scss']
})
export class NgxEditorComponent implements OnInit, OnDestroy {
  editor;
  plugin = new Plugin({
    key: new PluginKey('plugin'),
  });

  toolbar: Toolbar = [
    ['bold', 'italic'],
    ['underline', 'strike'],
    ['code', 'blockquote'],
    ['ordered_list', 'bullet_list'],
    [{ heading: ['h1', 'h2', 'h3', 'h4', 'h5', 'h6'] }],
    ['link', 'image'],
    ['text_color', 'background_color'],
    ['align_left', 'align_center', 'align_right', 'align_justify'],
  ];




  form = new FormGroup({
    editorContent: new FormControl('', Validators.required),
  });

  ngOnInit(): void {
    this.editor = new Editor({
      content: '',
      history: true,
      keyboardShortcuts: true,
      inputRules: true,
      plugins: [], //https://prosemirror.net/docs/guide/#state
      schema, //https://prosemirror.net/examples/schema/
      nodeViews: {}, //https://prosemirror.net/docs/guide/#state,
      attributes: {}, // https://prosemirror.net/docs/ref/#view.EditorProps.attributes
    });
    this.editor.registerPlugin(this.plugin);
    this.editor.commands
      .textColor('red')
      .insertText('Hello world!')
      .focus()
      .scrollIntoView()
      .exec();
  }

  ngOnDestroy(): void {
    this.editor.destroy();
  }
}
