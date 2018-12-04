<template>
  <form @submit.prevent="submit">
    <div class="flex pt-1">
      <!-- TypeText -> ddl [default plain] or html -->
      <label class="flex four">
        <span>Input type</span>
        <select v-model="typeText" class="three-fourth">
          <option value="plain" selected="selected">Plain (Default)</option>
          <option value="html">HTML</option>
        </select>
      </label>

      <label class="flex four">
        <span>From</span>
        <input v-model="from" type="text" placeholder="i.e.: en"  class="three-fourth" />
      </label>

      <label class="flex four">
        <span>From (Suggested)</span>
        <input v-model="fromSuggested" type="text" placeholder="i.e.: en"  class="three-fourth" />
      </label>
      
      <label class="flex four">
        <span>To*</span>
        <input v-model="to" type="text" placeholder="i.e.: fr,es" class="three-fourth" />
      </label>

      <label class="flex four">
        <span>Profanity action</span>
        <select v-model="profanityAction" class="three-fourth">
          <option value="NoAction" selected="selected">No action (default)</option>
          <option value="Marked">Marked</option>
          <option value="Deleted">Deleted</option>
        </select>
      </label>

      <label class="flex four">
        <span>Category</span>
        <input v-model="category" type="text" placeholder="Default: general" class="three-fourth" />
      </label>

      <label class="flex four">
        <span>Profanity marker</span>
        <select v-model="profanityMarker" class="three-fourth">
          <option value="Asterisk" selected="selected">Asterisk (default)</option>
          <option value="Tag">Tag</option>
        </select>
      </label>

      <div class="flex four">
        <label class="off-fourth three-fourth">
          <input id="includeAlignment" v-model="includeAlignment" type="checkbox">
          <span class="checkable">Include alignment</span>
        </label>
      </div>

      <div class="flex four">
        <label class="off-fourth three-fourth">
          <input v-model="includeSentenceLength" type="checkbox">
          <span class="checkable">Include sentence length</span>
        </label>
      </div>

      <label class="flex four">
        <span>From script</span>
        <input v-model="fromScript" type="text" placeholder="RTM" class="three-fourth" />
      </label>

      <label class="flex four">
        <span>To script</span>
        <input v-model="toScript" type="text" placeholder="RTM" class="three-fourth" />
      </label>
    </div>
  </form>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  data () {
    return {
      typeText: 'plain',
      from: 'en',
      fromSuggested: '',
      to: 'ja',
      profanityAction: 'NoAction',
      category: 'general',
      profanityMarker: 'Asterisk',
      includeAlignment: false,
      includeSentenceLength: false,
      fromScript: null,
      toScript: null
    }
  },
  watch: {
    typeText: function (val) {
      this['translator/setTranslateType']({ translateType: this.typeText })
    }
  },

  methods: {
    ...mapActions(['translator/setTranslateType']),

    submit: function () {
      this.$emit("submitOptions", this.getData())
    },

    getData: function () {
      var options = {
        typeText: this.typeText,
        from: this.from,
        fromSuggested: this.fromSuggested,
        to: this.to.split(','),
        profanityAction: this.profanityAction,
        category: this.category,
        profanityMarker: this.profanityMarker,
        includeAlignment: this.includeAlignment,
        includeSentenceLength: this.includeSentenceLength,
        fromScript: this.fromScript,
        toScript: this.toScript
      }

      return options
    }
  }
}
</script>
