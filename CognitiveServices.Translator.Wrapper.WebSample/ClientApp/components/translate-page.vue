<template>
    <div>
      <h1>Translate API Wrapper Demo</h1>

      <p>This demonstrates how the basics of the library.</p>

      <div class="row">

        <div class="col-md-4"> 
          <div class="card border-dark h-100">
            <div class="card-header text-white bg-dark">Options</div>
            <div class="card-body text-dark">
              <translate-options ref="options" />
            </div>
          </div>
        </div>
        <div class="col-md-8">
          <div class="card border-secondary">
            <div class="card-header text-white bg-secondary">
              Content
            </div>
            <div class="card-body text-dark">
              <h5><span id="inputType">{{translateType}}</span> to translate</h5>
              <textarea class="w-100"/>
              
              <button class="btn btn-primary float-md-right" @click="translate">Translate</button>
              <br><br><br>
              <h5>JSON Result:</h5> 
              <pre class="border p-1 border-secondary">
result will be displayed here.
              </pre>
            </div>
          </div>
        </div>
      </div>

  </div>
</template>

<script>
import translateOption from './translate/options'
import { mapState } from 'vuex'

export default {
  components: {
    "translate-options": translateOption 
  },
  
  data () {
    return {

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
    }
  }
}
</script>

<style>
</style>
