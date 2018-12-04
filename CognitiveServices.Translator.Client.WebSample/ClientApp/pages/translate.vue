<template>
  <div>
    <PageTitle title="Translate API Wrapper Demo" />

    <p>This demonstrates how the basics of the library.</p>
    <div class="flex one px-2 color-darkGray">
      <article class="card">
        <header>
          Content
        </header>

        <div class="px-2">
          <h5>
            <span id="inputType">
              {{ translateType }}
            </span> to translate
          </h5>
          <textarea
            v-model="textInput"
            class="border p-1"
          />
          <div class="text-right">
            <button @click="translate" :disabled="currentKey === ''">
              Translate
            </button>
          </div>

          <h5>JSON Result:</h5>
          <pre
            ref="translatedText"
            class="border p-1"
            style="margin:0px 0px 8px 0px"
          >
{{ translatedText }}
              </pre>
          <div class="text-right">
            <button @click="copyClipboard" :disabled="currentKey === ''">
              Copy Clipboard
            </button>
          </div>
        </div>
      </article>

      <article class="card">
        <header>
          Options
        </header>
        <div class="px-2">
          <TranslateOptions ref="options" />
        </div>
      </article>
    </div> <!-- End of row -->
  </div>
</template>

<script>
import TranslateOptions from 'components/options'
import { mapState } from 'vuex'

export default {
  components: {
    'TranslateOptions': TranslateOptions
  },

  data () {
    return {
      translatedText: 'result will be displayed here.',
      textInput: 'How are you?'
    }
  },

  computed: {
    ...mapState({
      currentKey: state => state.translator.cognitiveServicesKey,
      translateType: state => {
        return state.translator.translateType === 'plain' ? 'Text' : 'Html'
      }
    })
  },

  methods: {
    translate: function () {
      let context = this

      var translateRequest = {
        cognitiveServicesConfig: { subscriptionKey: this.currentKey },
        requestContents: [
          { text: this.textInput }
        ],
        options: this.$refs.options.getData()
      }

      // Todo use axios instead
      this.$http.put('api/translate', translateRequest).then(response => {
        if (response.request.readyState === 4 && response.status === 200) {
          context.translatedText = JSON.stringify(response.data, null, 4)
        }
      }).catch(e => console.log(e))
    },
    copyClipboard: function () {
      const textArea = document.createElement('textarea')
      textArea.textContent = this.translatedText
      document.body.append(textArea)
      textArea.select()

      try {
        var successful = document.execCommand('copy')
        var msg = successful ? 'Successfully' : 'Unsuccessfully'
        alert(`${msg} copied to the clipboard.`)
      } catch (err) {
        alert('Oops, unable to copy')
      }

      textArea.remove()
    }
  }
}
</script>
