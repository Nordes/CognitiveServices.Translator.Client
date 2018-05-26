<template>
    <div>
      <h1>Translate API Wrapper Demo</h1>

      <p>This demonstrates how the basics of the library.</p>
      <div class="row mb-3">
        <div class="col-md-12">
          <div class="card">
            <div class="card-header text-white bg-secondary">
              Content
            </div>
            <div class="card-body text-dark">
              <h5><span id="inputType">{{translateType}}</span> to translate</h5>
              <textarea class="w-100"/>
              
              <button class="btn btn-primary float-md-right" @click="translate">Translate</button>
              <br><br><br>
              <h5>JSON Result:</h5> 
              <pre ref="translatedText" class="border p-1 border-secondary">
{{translatedText}}
              </pre>

              <button class="btn btn-primary float-md-right" @click="copyClipboard">Copy Clipboard</button>
            </div>
          </div>
        </div>
      </div> <!-- End of row -->
      <div class="row">
        <div class="col-md-12"> 
          <div class="card">
            <div class="card-header text-white bg-secondary">Options</div>
            <div class="card-body text-dark">
              <translate-options ref="options" />
            </div>
          </div>
        </div>
      </div> <!-- End of row -->
  </div>
</template>

<script>
import translateOption from './options'
import { mapState } from 'vuex'

export default {
  components: {
    "translate-options": translateOption 
  },
  
  data () {
    return {
      translatedText: "result will be displayed here."
    }
  },

  computed: {
    ...mapState({
      currentKey: state => state.cognitiveServicesKey,
      translateType: state => {
        return state.translateType == 'plain' ? 'Text' : 'Html'
      },
    })
  },

  methods: {
    translate: function () {
      console.log(this.$refs.options.getData());
    },
    copyClipboard: function () {
      const textArea = document.createElement('textarea');
      textArea.textContent = this.translatedText;
      document.body.append(textArea);
      textArea.select();

      try {
        var successful = document.execCommand('copy');
        var msg = successful ? 'Successfully' : 'Unsuccessfully';
        alert(`${msg} copied to the clipboard.` );
      } catch (err) {
        alert('Oops, unable to copy');
      }

      textArea.remove();
    }
  }
}
</script>

<style>
</style>
