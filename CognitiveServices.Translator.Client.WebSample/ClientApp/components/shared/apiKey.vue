<template>
  <div>
    <form>
      <div class="form-group row">
        <div class="col-sm-12">
          <input type="text" class="form-control" v-model="apiKey" placeholder="Cognitives Svc Api Key">
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  data() {
    return {
      apiKey: ''
    }
  },
  watch: {
    apiKey: function (val) {
      this.setCognitiveSvcKey({cognitiveServicesKey: this.apiKey})
    }
  }, 

  methods: {
    ...mapActions(['setCognitiveSvcKey']),
  }
}
</script>
